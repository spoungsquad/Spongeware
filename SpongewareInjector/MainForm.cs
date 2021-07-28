using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpongewareInjector
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void GitLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/notcarlton/Spongeware");
        }

        private void DevCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SelectButton.Enabled = DevCheckBox.Checked;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                StatusText.Text = "Selected " + FileDialog.SafeFileName;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            if (!DevCheckBox.Checked)
                MessageBox.Show("This button doesn't do anything yet for non-developers. Select a developer DLL.", "Load", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                if (FileDialog.FileName == "")
                    StatusText.Text = "Status: No DLL selected.";
                else
                {
                    LoadDLL(FileDialog.FileName);
                }
            }
        }

        IntPtr asm;

        public void LoadDLL(string path)
        {
            Process[] SpongeGlockIndex = Process.GetProcessesByName("SpongeGlock SquarePants");
            if (SpongeGlockIndex.Length == 0)
                StatusText.Text = "Status: SpongeGlock isn't open";
            else
            {
                StatusText.Text = "Status: Found SpongeGlock";
                Process SpongeGlock = SpongeGlockIndex[0];

                IntPtr handle = Native.OpenProcess(ProcessAccessRights.PROCESS_ALL_ACCESS, false, SpongeGlock.Id);

                if (handle == IntPtr.Zero)
                {
                    StatusText.Text = "Status: Failed to open process";
                    return;
                }

                byte[] file;

                try
                {
                    file = File.ReadAllBytes(path);
                }
                catch
                {
                    StatusText.Text = "Status: Failed to read DLL";
                    return;
                }

                LoadButton.Enabled = false;
                StatusText.Text = "Status: Loading Spongeware...";

                IntPtr monoProcess;

                ProcessUtils.GetMonoModule(handle, out monoProcess);

                using (Injector injector = new Injector(handle, monoProcess))
                {
                    try
                    {
                        asm = injector.Inject(file, "Spongeware", "Loader", "Load");

                        StatusText.Text = "Injected at " + asm;
                        UnloadButton.Enabled = true;
                    }
                    catch (InjectorException ie)
                    {
                        StatusText.Text = "Failed to load";
                        MessageBox.Show("The loader threw this message: " + ie.Message, "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadButton.Enabled = true;
                    }
                    catch (Exception e)
                    {
                        StatusText.Text = "An unknown error occurred";
                        MessageBox.Show("Something very weird just happened: " + e.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LoadButton.Enabled = true;
                    }
                }
            }
        }

        private void UnloadButton_Click(object sender, EventArgs e)
        {
            UnloadDLL();
        }

        public void UnloadDLL()
        {
            Process[] SpongeGlockIndex = Process.GetProcessesByName("SpongeGlock SquarePants");
            if (SpongeGlockIndex.Length == 0)
                StatusText.Text = "Status: SpongeGlock isn't open";
            else
            {
                StatusText.Text = "Status: Found SpongeGlock";
                Process SpongeGlock = SpongeGlockIndex[0];

                IntPtr handle = Native.OpenProcess(ProcessAccessRights.PROCESS_ALL_ACCESS, false, SpongeGlock.Id);

                if (handle == IntPtr.Zero)
                {
                    StatusText.Text = "Status: Failed to open process";
                    return;
                }

                UnloadButton.Enabled = false;
                StatusText.Text = "Unloading Spongeware...";

                IntPtr monoProcess;

                ProcessUtils.GetMonoModule(handle, out monoProcess);

                using (Injector injector = new Injector(handle, monoProcess))
                {
                    try
                    {
                        injector.Eject(asm, "Spongeware", "Loader", "Unload");
                        StatusText.Text = "Unloaded at " + asm;
                        LoadButton.Enabled = true;
                    }
                    catch (InjectorException ie)
                    {
                        StatusText.Text = "Failed to unload";
                        MessageBox.Show("The injector threw this message: " + ie.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UnloadButton.Enabled = true;
                    }
                    catch (Exception e)
                    {
                        StatusText.Text = "An unknown error occurred";
                        MessageBox.Show("Something very weird just happened: " + e.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UnloadButton.Enabled = true;
                    }
                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (UnloadButton.Enabled)
                UnloadDLL();
        }
    }
}
