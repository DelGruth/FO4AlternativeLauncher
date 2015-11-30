using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using FO4AlternativeLauncher.Common;
using System.Diagnostics;
namespace FO4AlternativeLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] PossibleIniFilePaths = new string[] {
        @"C:\Users\" + Environment.UserName + @"\Documents\My Games\Fallout4\",
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+ @"\My Games\Fallout4\"};
        GlobalVar GlobalVar = new GlobalVar();
        public static string[] PossibleFallout4Paths = new string[] { @"C:\Program Files (x86)\Fallout 4\Fallout4.exe", @"C:\Program Files (x86)\Steam\SteamApps\common\Fallout 4\Fallout4.exe", @"C:\Steam\SteamApps\common\Fallout 4\Fallout4.exe" };
        public static int exeIndex;
        public static int filePathIndex;
        public static Console Console;
        public static string exePath;
        bool ratio169Selected = false;
        bool ratio1610Selected = false;

        public MainWindow()
        {
            try {
                Console = new Console();
                InitializeComponent();

                for (int i = 0; i < PossibleFallout4Paths.Length; i++)
                {
                    if (File.Exists(PossibleFallout4Paths[i])) {
                        exeIndex = i;
                    } else
                    {
                        exeIndex = -1;
                    }
                }
                InitializeApplication();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message + " || " +e.Source.ToString() + " || "+ e.StackTrace );
            }
        }

        //Init app & load relevant values 
        bool InitializeApplication()
        {
            try {
                bool exists = false;
                for (int i = 0; i < PossibleIniFilePaths.Length; i++)
                {
                    if (File.Exists(PossibleIniFilePaths[i] + "Fallout4.ini"))
                    {
                        exists = true;
                        fallout4inifolder.Text = PossibleIniFilePaths[i];
                        filePathIndex = i;
                        GlobalVar.ReadFallout4PrefIni();
                        LoadValues();
                        Exetolaunch.Text = GlobalVar.EXEPath.VarValue;
                    }
                }
                if (exists == false)
                {
                    try
                    {
                        if (File.Exists(GlobalVar.GetIniFolder() + "Fallout4.ini"))
                        {
                            fallout4inifolder.Text = GlobalVar.GetIniFolder();
                            GlobalVar.ReadFallout4PrefIni();
                            LoadValues();
                            Exetolaunch.Text = GlobalVar.EXEPath.VarValue;
                            exists = true;
                            if (Convert.ToInt32(GlobalVar.OpenConsole.VarValue) == 1)
                            {
                                Console.Show();
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteToConsole("null");
                    }
                }
                if (!Directory.Exists("./Profiles"))
                {
                    Directory.CreateDirectory("./Profiles");
                }
                if (!exists)
                {
                    MessageBox.Show("Could not find Fallout4 Settings path,set it manually in the launcher tab,settings won't be saved correctly");
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " || " + e.Source.ToString() + " || " + e.StackTrace);
                return false;
            }
        }
     
        //Convert variables to visual representation
       public void LoadValues()
        {
            if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 450 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 720 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 810 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1080)
            {
                Aspect_Ratio.SelectedIndex = 0;
                ratio169Selected = true;
                ratio1610Selected = false;

                if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 450)
                {
                    Resolution_ComboBox.SelectedIndex = 0;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 720)
                {
                    Resolution_ComboBox.SelectedIndex = 1;

                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 810)
                {
                    Resolution_ComboBox.SelectedIndex = 2;

                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1080)
                {
                    Resolution_ComboBox.SelectedIndex = 3;

                }

            }

            else if(Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 500 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 640 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 800 ||
               Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 900||
                Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1050)
            {
                if (Aspect_Ratio.SelectedIndex == GlobalVar.AspectRatio1610)
                {
                    ratio169Selected = false;
                    ratio1610Selected = true;
                    Aspect_Ratio.SelectedIndex = 1;
                }
                if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 500)
                {
                    Resolution_ComboBox.SelectedIndex = 0;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 640)
                {
                    Resolution_ComboBox.SelectedIndex = 1;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 800)
                {
                    Resolution_ComboBox.SelectedIndex = 2;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 900)
                {
                    Resolution_ComboBox.SelectedIndex = 3;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1050)
                {
                    Resolution_ComboBox.SelectedIndex = 4;
                }

            }
            else
            {
                ratio1610Selected = false;
                ratio169Selected = false;
                Aspect_Ratio.SelectedIndex = 2;
                if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 768)
                {
                    Resolution_ComboBox.SelectedIndex = 0;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 864)
                {
                    Resolution_ComboBox.SelectedIndex = 1;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 960)
                {
                    Resolution_ComboBox.SelectedIndex = 2;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1050)
                {
                    Resolution_ComboBox.SelectedIndex = 3;
                }
                else if (Convert.ToInt32(GlobalVar.Resolution_Height.VarValue) == 1200)
                {
                    Resolution_ComboBox.SelectedIndex = 4;
                }

            }
            if (GlobalVar.sAntiAliasing.VarValue == GlobalVar.sAntiAliasingHigh)
            {
                Console.WriteToConsole("AntiAliasing value "+GlobalVar.sAntiAliasing.VarValue);
                Antianialising.SelectedIndex = 2;
            }
          else if ( GlobalVar.sAntiAliasing.VarValue == GlobalVar.sAntiAliasing_Low)
            {
                Antianialising.SelectedIndex = 1;
            }
            else if (GlobalVar.sAntiAliasing.VarValue == GlobalVar.sAntiAliasing_Off)
            {
                Antianialising.SelectedIndex = 0;

            }else
            {
                Antianialising.SelectedIndex = 0;
                Console.WriteToConsole("Antianialising unknown setting to off");
            }


            if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 1)
            {
                AnisotropicSetting.SelectedIndex = 0;
            }
            else if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 2)
            {
                AnisotropicSetting.SelectedIndex = 1;

            }
            else if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 4)
            {
                AnisotropicSetting.SelectedIndex = 2;

            }
            else if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 8)
            {
                AnisotropicSetting.SelectedIndex = 3;

            }
            else if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 12)
            {
                AnisotropicSetting.SelectedIndex = 4;

            }
            else if (Convert.ToInt32(GlobalVar.iMaxAnisotropy.VarValue) == 16)
            {
                AnisotropicSetting.SelectedIndex = 5;
            }


            if (Convert.ToInt32(GlobalVar.TextureQuality.VarValue) == GlobalVar.TextureQualityLow)
            {
                Texture_Quality.SelectedIndex = 0;

            }
            else if (Convert.ToInt32(GlobalVar.TextureQuality.VarValue) == GlobalVar.TextureQuality_Medium)
            {
                Texture_Quality.SelectedIndex = 1;
            }
            else if(Convert.ToInt32(GlobalVar.TextureQuality.VarValue) == GlobalVar.TextureQuality_High)
            {
                Texture_Quality.SelectedIndex = 2;
            }
            else if (Convert.ToInt32(GlobalVar.TextureQuality.VarValue) == GlobalVar.TextureQuality_Ultra)
            {
                Texture_Quality.SelectedIndex = 3;
            }

            if(Convert.ToInt32(GlobalVar.ShadowQuality.VarValue) == GlobalVar.ShadowQuality_VeryLow)
            {
                Shadow_Quality.SelectedIndex = 0;
            }else if (Convert.ToInt32(GlobalVar.ShadowQuality.VarValue) == GlobalVar.ShadowQuality_Low)
            {
                Shadow_Quality.SelectedIndex = 1;
            }
            else if (Convert.ToInt32(GlobalVar.ShadowQuality.VarValue) == GlobalVar.ShadowQuality_Medium)
            {
                Shadow_Quality.SelectedIndex = 2;
            }
            else if (Convert.ToInt32(GlobalVar.ShadowQuality.VarValue) == GlobalVar.ShadowQuality_High)
            {
                Shadow_Quality.SelectedIndex = 3;
            }
            else if (Convert.ToInt32(GlobalVar.ShadowQuality.VarValue) == GlobalVar.ShadowQuality_Ultra)
            {
                Shadow_Quality.SelectedIndex = 4;
            }

            if(Convert.ToSingle(GlobalVar.fShadowDistance.VarValue) == GlobalVar.fShadowDistance_Medium)
            {
                Shadow_Distance.SelectedIndex = 0;
            }
            else if (Convert.ToInt32(GlobalVar.fShadowDistance.VarValue) == GlobalVar.fShadowDistance_High)
            {
                Shadow_Distance.SelectedIndex = 1;

            }
            else if (Convert.ToInt32(GlobalVar.fShadowDistance.VarValue) == GlobalVar.fShadowDistance_Ultra)
            {
                Shadow_Distance.SelectedIndex = 2;

            }

            if (Convert.ToInt32(GlobalVar.bDecals.VarValue) == 0|| Convert.ToInt32(GlobalVar.uMaxDecals.VarValue) == GlobalVar.uMaxDecals_None) {
                Decal_Quantity.SelectedIndex = 0;
            }
            else if (Convert.ToInt32(GlobalVar.uMaxSkinDecals.VarValue) == GlobalVar.uMaxSkinDecals_Medium)
            {
                Decal_Quantity.SelectedIndex = 1;
            }
            else if (Convert.ToInt32(GlobalVar.uMaxSkinDecals.VarValue) == GlobalVar.uMaxSkinDecals_High)
            {
                Decal_Quantity.SelectedIndex = 2;
            }
            else if (Convert.ToInt32(GlobalVar.uMaxSkinDecals.VarValue) == GlobalVar.uMaxSkinDecals_Ultra)
            {
                Decal_Quantity.SelectedIndex = 3;
            }


            if (Convert.ToInt32(GlobalVar.bForceIgnoreSmoothness.VarValue )== GlobalVar.bForceIgnoreSmoothness_Medium)
            {
                Lighting_Quality.SelectedIndex  = 0;
            }else if (Convert.ToInt32(GlobalVar.bForceIgnoreSmoothness.VarValue) == GlobalVar.bForceIgnoreSmoothness_High && Convert.ToInt32(GlobalVar.bScreenSpaceSubsurfaceScattering.VarValue) == GlobalVar.bScreenSpaceSubsurfaceScattering_Low)
            {
                Lighting_Quality.SelectedIndex = 1;
            }
            else if (Convert.ToInt32(GlobalVar.bForceIgnoreSmoothness.VarValue) == GlobalVar.bForceIgnoreSmoothness_High && Convert.ToInt32(GlobalVar.bScreenSpaceSubsurfaceScattering.VarValue) == GlobalVar.bScreenSpaceSubsurfaceScattering_Ultra)
            {
                Lighting_Quality.SelectedIndex = 2;
            }

   

            if (Convert.ToInt32(GlobalVar.bVolumetricLightingEnable.VarValue) == 0)
            {
                GodRays_Quality.SelectedIndex = 0;
            }
            else if (Convert.ToInt32(GlobalVar.iVolumetricLightingQuality.VarValue) == GlobalVar.iVolumetricLightingQuality_Low && Convert.ToInt32(GlobalVar.bVolumetricLightingEnable.VarValue) == 1)
            {
                GodRays_Quality.SelectedIndex = 1;
            }
            else if (Convert.ToInt32(GlobalVar.iVolumetricLightingQuality.VarValue) == GlobalVar.iVolumetricLightingQuality_Medium)
            {
                GodRays_Quality.SelectedIndex = 2;
            }
            else if (Convert.ToInt32(GlobalVar.iVolumetricLightingQuality.VarValue) == GlobalVar.iVolumetricLightingQuality_High)
            {
                GodRays_Quality.SelectedIndex = 3;
            }
            else if (Convert.ToInt32(GlobalVar.iVolumetricLightingQuality.VarValue) == GlobalVar.iVolumetricLightingQuality_Ultra)
            {
                GodRays_Quality.SelectedIndex = 4;
            }


            if (Convert.ToInt32(GlobalVar.bDoDepthOfField.VarValue )== 1 && Convert.ToInt32(GlobalVar.bScreenSpaceBokeh.VarValue) != GlobalVar.bScreenSpaceBokeh_High)
            {
                DOF.SelectedIndex = 0;
            }else if (Convert.ToInt32(GlobalVar.bScreenSpaceBokeh.VarValue) == GlobalVar.bScreenSpaceBokeh_High && Convert.ToInt32(GlobalVar.bDoDepthOfField.VarValue) == 1)
            {
                DOF.SelectedIndex = 1;
            }

            if(Convert.ToInt32(GlobalVar.bSAOEnable.VarValue) == 0)
            {
                Ambient_OClussion.SelectedIndex = 0;

            }else if ( Convert.ToInt32 ( GlobalVar.bSAOEnable.VarValue) == 1)
            {
                Ambient_OClussion.SelectedIndex = 1;
            }

            if (Convert.ToInt32(GlobalVar.bFull_Screen.VarValue) == 0)
            {
                WindowedMode.IsChecked = true;

            }
            else if (Convert.ToInt32(GlobalVar.bFull_Screen.VarValue) == 1)
            {
                WindowedMode.IsChecked = false;
            }

            if(Convert.ToInt32(GlobalVar.bBorderless.VarValue) == 0)
            {
                Borderless.IsChecked = false;

            }else
            {
                Borderless.IsChecked = true;
            }

            if (Convert.ToInt32(GlobalVar.bLensFlare.VarValue) == 0)
            {
                LensFlare.IsChecked = false;

            }
            else if (Convert.ToInt32(GlobalVar.bLensFlare.VarValue) == 1)
            {
                LensFlare.IsChecked = true;
            }
            if (Convert.ToInt32(GlobalVar.bMBEnable.VarValue) == 0)
            {
                BlurMotion.IsChecked = false;

            }
            else if (Convert.ToInt32(GlobalVar.bMBEnable.VarValue) == 1)
            {
                BlurMotion.IsChecked = true;
            }

            if (Convert.ToInt32(GlobalVar.bEnableRainOcclusion.VarValue) == 0)
            {
                RainOC.IsChecked = false;

            }
            else if (Convert.ToInt32(GlobalVar.bEnableRainOcclusion.VarValue) == 1)
            {
                RainOC.IsChecked = true;
            }

            if (Convert.ToInt32(GlobalVar.bEnableWetnessMaterials.VarValue) == 0)
            {
                Wetness.IsChecked = false;

            }
            else if (Convert.ToInt32(GlobalVar.bEnableWetnessMaterials.VarValue) == 1)
            {
                Wetness.IsChecked = true;
            }

            if (Convert.ToInt32(GlobalVar.bScreenSpaceReflections.VarValue) == 0)
            {
                SSR.IsChecked = false;

            }
            else if (Convert.ToInt32(GlobalVar.bScreenSpaceReflections.VarValue) == 1)
            {
                SSR.IsChecked = true;
            }



            if (Convert.ToInt32(GlobalVar.Vsync.VarValue) == 0)
            {
                Vsync.IsChecked = false;

            }
            else
            {
                Vsync.IsChecked = true;
            }

            fov1.Text = GlobalVar.FOV_1st.VarValue;
            fov3.Text = GlobalVar.FOV_3rd.VarValue;
            MaxParticles.Text = GlobalVar.MaxParticles.VarValue;


            ActorFade.Value = Convert.ToDouble(GlobalVar.ActorFade.VarValue);
            GrassFade.Value = Convert.ToDouble(GlobalVar.GrassFade.VarValue);
            ItemFade.Value = Convert.ToDouble(GlobalVar.ItemFade.VarValue);
            ObjectFade.Value = Convert.ToDouble(GlobalVar.ObjectFade.VarValue);

            NumberOfCpuCores_Copy.Text = GlobalVar.iNumHWThreads.VarValue.ToString();



            if(Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_Off){
                GrassQuality.SelectedIndex = 0;
            }
            else if (Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_Low)
            {
                GrassQuality.SelectedIndex = 1;
            }
            else if (Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_Medium)
            {
                GrassQuality.SelectedIndex = 2;
            }
            else if (Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_High)
            {
                GrassQuality.SelectedIndex = 3;
            }
            else if (Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_VeryHigh)
            {
                GrassQuality.SelectedIndex = 4;
            }
            else if (Convert.ToInt32(GlobalVar.iMinGrassSize.VarValue) == GlobalVar.iMinGrassSize_Ultra)
            {
                GrassQuality.SelectedIndex = 5;
            }


            if (Convert.ToInt32(GlobalVar.bShowTutorials.VarValue) == 0)
            {
                DisableTutorialPopups.IsChecked = false;
            }
            else
            {
                DisableTutorialPopups.IsChecked = true;
            }
            if (Convert.ToString(GlobalVar.SkipIntro.VarValue) == "GameIntro_V3_B.bk2")
            {
                SkipIntro.IsChecked = false;
            }
            else
            {
                SkipIntro.IsChecked = true;
            }

            if(Convert.ToInt32(GlobalVar.bMaximizeWindow.VarValue) == 1)
            {
                Stretch_to_fit.IsChecked = true;
            }else
            {
                Stretch_to_fit.IsChecked = false;
            }


            if (Convert.ToInt32(GlobalVar.bMultiThreadedRendering.VarValue) == 1)
            {
                EnableRenderThreading.IsChecked = true;
            }
            else
            {
                EnableRenderThreading.IsChecked = false;
            }
            if (Convert.ToInt32(GlobalVar.bDisableAllGore.VarValue) == 1)
            {
                DisableGore.IsChecked = true;
            }
            else
            {
                DisableGore.IsChecked = false;
            }
            if (Convert.ToInt32(GlobalVar.bGamepadEnable.VarValue) == 1)
            {
                EnableGamePad.IsChecked = true;
            }
            else
            {
                EnableGamePad.IsChecked = false;
            }
            if (Convert.ToInt32(GlobalVar.bCrosshairEnabled.VarValue) == 1)
            {
                EnableCrossair.IsChecked = true;
            }
            else
            {
                EnableCrossair.IsChecked = false;
            }
            if (Convert.ToInt32(GlobalVar.bEssentialTakeNoDamage.VarValue) == 1)
            {
                EssentialKillable.IsChecked = true;
            }
            else
            {
                EssentialKillable.IsChecked = false;
            }
            

            AutoSaveEveryXMin.Text = GlobalVar.fAutosaveEveryXMins.VarValue.ToString();
            _3rdPersonaimfov.Text = GlobalVar.f3rdPersonAimFOV.VarValue.ToString();
            if (Convert.ToInt32(GlobalVar.bForceNPCsUseAmmo.VarValue) == 1)
            {
                NPCsUseAmmo.IsChecked = true;
            }
            else
            {
                NPCsUseAmmo.IsChecked = false;
            }

            DefaultWaithours_input.Text = GlobalVar.iDefaultWaitHours.VarValue.ToString();
        }

        //Export a custom preset of values
        private void Export_Settings(object sender, RoutedEventArgs arg)
        {

            try {
                //set default directory
                SetAllVarValues();
                Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
                saveFile.Filter = "XML (*.xml)|*.xml";
                saveFile.InitialDirectory = Environment.CurrentDirectory + @"\Profiles";
                saveFile.AddExtension = true;
                string name;
                if (saveFile.ShowDialog() == true) {
                    name = saveFile.FileName;
                    GlobalVar.WriteFallout4PrefIni(name);
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " || " + e.Source.ToString() + " || " + e.StackTrace);
            }
        }

        //Import a custom preset of values
        private void Import_Settings(object sender, RoutedEventArgs arg)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
                openFile.Filter = "XML (*.xml)|*.xml";
                openFile.InitialDirectory = Environment.CurrentDirectory + @"\Profiles";
                openFile.AddExtension = true;
                string name;
                if (openFile.ShowDialog() == true)
                {
                    name = openFile.FileName;
                    bool done = GlobalVar.ReadFallout4PrefIni(name);
                    LoadValues();
                    Console.WriteToConsole("done reading import");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " || " + e.Source.ToString() + " || " + e.StackTrace);
            }
        }

        //Show Console
        private void MenuItem_Click(object sender, RoutedEventArgs arg)
        {
            if (Convert.ToInt32(GlobalVar.OpenConsole.VarValue) == 0)
            {
                GlobalVar.OpenConsole.ChangeValue(1); 
                Console.Show();
            }
            else
            {
                GlobalVar.OpenConsole.ChangeValue(0);
                Console.Hide();
            }
        }

        //Called when main window is closing
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs arg)
        {
            GlobalVar.WriteDefaultIni();
            Environment.Exit(0);
        }

        //Generate new resolution values
        private void Aspect_Ratio_SelectionChanged(object sender, SelectionChangedEventArgs arg)
        {
            if (Aspect_Ratio.SelectedIndex == GlobalVar.AspectRatio_169)// && ratio169Selected ==false)
            {
                ratio169Selected = true;
                ratio1610Selected = false;
                Resolution_ComboBox.Items.Clear();
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "800 x 450" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1280 x 720" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1440 x 810" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1920 x 1080" });
            }
            else if (Aspect_Ratio.SelectedIndex == GlobalVar.AspectRatio1610 )
            {
                ratio169Selected = false;
                 ratio1610Selected = true;

                Resolution_ComboBox.Items.Clear();
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "800 x 500" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1024 x 640" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1280 x 800" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1440 x 900" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1680 x 1050" });
            }else if (Aspect_Ratio.SelectedIndex == 2)
            {
                ratio169Selected = false;
                 ratio1610Selected = false;
                Resolution_ComboBox.Items.Clear();
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1024 x 768" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1152 x 864" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1280 x 960" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1400 x 1050" });
                Resolution_ComboBox.Items.Add(new ListBoxItem { Content = "1600 x 1200" });
            }

        }

        //Exit Button Click 
        private void button_Click(object sender, RoutedEventArgs arg)
        {
            Environment.Exit(0);
        }

        //Save INI
        private void SaveButton_Click(object sender, RoutedEventArgs arg)
        {
            SetAllVarValues();
            GlobalVar.WriteFallout4PrefIni();
        }

        //Custom .exe path
        private void button2_Click(object sender, RoutedEventArgs arg)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Executable (*.exe)|*.exe";
            if (dlg.ShowDialog() == true)
            {

                GlobalVar.EXEPath.ChangeValue(dlg.FileName);
                Exetolaunch.Text = GlobalVar.EXEPath.VarValue.ToString();
            }
        }

        // Launch the custom executable
        private void button1_Click(object sender, RoutedEventArgs arg)
        {
            if (File.Exists(GlobalVar.EXEPath.VarValue))
            {
                Process.Start(new ProcessStartInfo
                {
                    //  RedirectStandardInput = true,
                    WorkingDirectory = Path.GetDirectoryName(GlobalVar.EXEPath.VarValue),
                    FileName = Path.GetFileName(GlobalVar.EXEPath.VarValue)
                });
            }
            else
            {
                MessageBox.Show("Set a valid path in the launcher tab.");
            }
        }

        //Change Fallout4.ini path
        private void NewSettingdlg_Click(object sender, RoutedEventArgs arg)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.Filter = "Fallout4.ini|Fallout4.ini";
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;

            if (dlg.ShowDialog() == true)
            {
                fallout4inifolder.Text = Path.GetDirectoryName(dlg.FileName);
                GlobalVar.Fallout4IniFolder.ChangeValue(Path.GetDirectoryName(dlg.FileName));
                GlobalVar.ReadFallout4PrefIni();
                LoadValues();
                Console.WriteToConsole("Changed fallout4 ini path, value: " + dlg.FileName);
            }
        }

        //Exit button clicked
        private void button_Click_1(object sender, RoutedEventArgs arg)
        {
            GlobalVar.WriteDefaultIni();
            Environment.Exit(0);
        }

        //Set all variables according to current selected value
        void SetAllVarValues()
        {
            try {
                SetDefaultWaitHours();
                SetNPCsUseAmmo();
                Set3rdPersonAimFOV();
                SetAutoSaveInterval();
                SetEnableCrossair();
                SetEnableGamepad();
                SetDisableGore();
                SetEssentialNPCKillable();
                SetMultithreadedRendering();
                SetFpsLock();
                SetFoV();
                SetFadeSettings();
                SetMaxParticles();
                SetCPUCoreValues();
                SetGrassQuality();
                SetDisableTutorialPopups();
                SetIntroSkip();
                SetDisableAnalytics();
                SetLaunchersDefaultSettings();
                SetFitToScreen();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + " || " + e.Source.ToString() + " || " + e.StackTrace);
            }

        }

        private void SetDefaultWaitHours()
        {
            if(Convert.ToInt32(DefaultWaithours_input.Text) < 24)
                GlobalVar.iDefaultWaitHours.ChangeValue(DefaultWaithours_input.Text);
            else if (Convert.ToInt32(DefaultWaithours_input.Text) > 0)
                GlobalVar.iDefaultWaitHours.ChangeValue(24);
            else if (Convert.ToInt32(DefaultWaithours_input.Text) < 0)
                GlobalVar.iDefaultWaitHours.ChangeValue(1);

        }

        private void SetNPCsUseAmmo()
        {
            GlobalVar.bForceNPCsUseAmmo.ChangeValueAuto(Convert.ToInt32(NPCsUseAmmo.IsChecked));
        }

        private void Set3rdPersonAimFOV()
        {
            GlobalVar.f3rdPersonAimFOV.ChangeValue(Convert.ToSingle(_3rdPersonaimfov.Text));
        }

        private void SetAutoSaveInterval()
        {
            GlobalVar.fAutosaveEveryXMins.ChangeValue((Convert.ToSingle(AutoSaveEveryXMin.Text)));
        }

        private void SetEnableCrossair()
        {
            GlobalVar.bCrosshairEnabled.ChangeValueAuto(Convert.ToInt32(EnableCrossair.IsChecked));
        }

        private void SetEnableGamepad()
        {
            GlobalVar.bGamepadEnable.ChangeValueAuto(Convert.ToInt32(EnableGamePad.IsChecked));
        }

        private void SetDisableGore()
        {
            GlobalVar.bDisableAllGore.ChangeValueAuto(Convert.ToInt32(DisableGore.IsChecked));
            GlobalVar.bBloodSplatterEnabled.ChangeValueAuto(Convert.ToInt32(DisableGore.IsChecked));

        }

        private void SetEssentialNPCKillable()
        {
            GlobalVar.bEssentialTakeNoDamage.ChangeValueAuto(Convert.ToInt32(EssentialKillable.IsChecked));
        }

        private void SetMultithreadedRendering()
        {
            GlobalVar.bMultiThreadedRendering.ChangeValueAuto(Convert.ToInt32(EnableRenderThreading.IsChecked));
        }

        private void SetFitToScreen()
        {
            GlobalVar.bMaximizeWindow.ChangeValueAuto(Convert.ToInt32(Stretch_to_fit.IsChecked));

        }

        //Set settings which are included in the default fallout4 launcher
        public void SetLaunchersDefaultSettings()
        {
            SetLensFlare();
            SetBlurMotion();
            SetRainOcclusion();
            SetWetness();
            SetSSR();
            SetWindowMode();
            SetAnisotropic();
            SetAntiAliasing();
            SetResolution();
            SetTextureQuality();
            SetShadowQuality();
            SetShadowDistance();
            SetDecalQuantity();
            SetLightingQuality();
            SetGodRayQuality();
            SetDOFQuality();
            SetAmbientOcclusion();
        }

        #region Custom Launcher settings
        private void SetDisableAnalytics()
        {
            if (Convert.ToBoolean(Force_Disable_Analytics.IsChecked))
            {
                GlobalVar.bEnablePlatform.ChangeValueAuto(0);
                GlobalVar.bEnableAnalytics.ChangeValueAuto(0);
            }else
            {
                Console.WriteToConsole("Skipping Analytics setting");
            }

        }

        private void SetDisableTutorialPopups()
        {
            GlobalVar.bShowTutorials.ChangeValueAuto(Convert.ToInt32(DisableTutorialPopups.IsChecked));
        }

        private void SetIntroSkip()
        {
            GlobalVar.SkipIntro.ChangeValueAuto(Convert.ToInt32(SkipIntro.IsChecked));
        }

        private void SetGrassQuality()
        {
            if(GrassQuality.SelectedIndex == 0)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_Off);
                GlobalVar.bAllowCreateGrass.ChangeValue(0);
                GlobalVar.bAllowLoadGrass.ChangeValue(0);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(-1);
            }
            else if (GrassQuality.SelectedIndex == 1)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_Low);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.bAllowLoadGrass.ChangeValue(0);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(7);
            }
            else if (GrassQuality.SelectedIndex == 2)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_Medium);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.bAllowLoadGrass.ChangeValue(0);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(15);
            }
            else if (GrassQuality.SelectedIndex == 3)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_High);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.bAllowLoadGrass.ChangeValue(0);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(20);
            }
            else if (GrassQuality.SelectedIndex == 4)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_VeryHigh);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.bAllowLoadGrass.ChangeValue(1);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(25);
            }
            else if (GrassQuality.SelectedIndex == 5)
            {
                GlobalVar.iMinGrassSize.ChangeValue(GlobalVar.iMinGrassSize_Ultra);
                GlobalVar.bAllowLoadGrass.ChangeValue(1);
                GlobalVar.bAllowCreateGrass.ChangeValue(1);
                GlobalVar.iMaxGrassTypesPerTexure.ChangeValue(30);
            }
        }

        private void SetCPUCoreValues()
        {
            GlobalVar.iNumHWThreads.ChangeValue(NumberOfCpuCores_Copy.Text);
            if(Convert.ToInt32(NumberOfCpuCores_Copy.Text) > 5)
            {
                GlobalVar.iNumThreads.ChangeValue(5);
            }else
            {
                GlobalVar.iNumThreads.ChangeValue(NumberOfCpuCores_Copy.Text);
            }
        }

        private void SetFadeSettings()
        {
            GlobalVar.ActorFade.ChangeValue(ActorFade_Text.Text);
            GlobalVar.GrassFade.ChangeValue(GrassFade_Text.Text);
            GlobalVar.ItemFade.ChangeValue(ItemFade_Text.Text);
            GlobalVar.ObjectFade.ChangeValue(ObjectFade_Text.Text);
        }

        private void SetMaxParticles()
        {
            GlobalVar.MaxParticles.ChangeValue(MaxParticles.Text);
        }

        private void SetFoV()
        {
            GlobalVar.FOV_1st.ChangeValue(fov1.Text);
            GlobalVar.FOV_3rd.ChangeValue(fov3.Text);
        }

        private void SetFpsLock()
        {
            if ((bool)Vsync.IsChecked)
            {
                GlobalVar.Vsync.ChangeValue(GlobalVar.Vsync_On);
            }else
            {
                GlobalVar.Vsync.ChangeValue(GlobalVar.Vsync_Off);
            }
        }
        #endregion 

        #region Default Launcher Settings
        private void SetLensFlare()
        {
            if ((bool)LensFlare.IsChecked)
            {
                GlobalVar.bLensFlare.ChangeValue(1);
            }
            else
            {
                GlobalVar.bLensFlare.ChangeValue(0);
            }
        }

        private void SetBlurMotion()
        {
            if ((bool)BlurMotion.IsChecked)
            {
                GlobalVar.bMBEnable.ChangeValue(1);
            }else
            {
                GlobalVar.bMBEnable.ChangeValue(0);
            }
        }

        private void SetRainOcclusion()
        {
            if ((bool)RainOC.IsChecked)
            {
                GlobalVar.bEnableRainOcclusion.ChangeValue(1);
            }
            else
            {
                GlobalVar.bEnableRainOcclusion.ChangeValue(0);
            }

            
        }

        private void SetWetness()
        {
            if ((bool)Wetness.IsChecked)
            {
                GlobalVar.bEnableWetnessMaterials.ChangeValue(1);
            }
            else
            {
                GlobalVar.bEnableWetnessMaterials.ChangeValue(0);
            }
        }

        private void SetSSR()
        {
            if ((bool)SSR.IsChecked)
            {
                GlobalVar.bScreenSpaceReflections.ChangeValue(1);
            }
            else
            {
                GlobalVar.bScreenSpaceReflections.ChangeValue(0);
            }
        }

        private void SetWindowMode()
        {
            if ((bool)WindowedMode.IsChecked)
            {
                GlobalVar.bFull_Screen.ChangeValue(0);
                if ((bool)Borderless.IsChecked)
                {
                    GlobalVar.bBorderless.ChangeValue(1);
                }else
                {
                    GlobalVar.bBorderless.ChangeValue(0);
                }
                if( (bool)(Stretch_to_fit.IsChecked))
                {
                    GlobalVar.bMaximizeWindow.ChangeValue(1);
                }
                else
                {
                    GlobalVar.bMaximizeWindow.ChangeValue(0);
                }
            }
            else
            {
                GlobalVar.bFull_Screen.ChangeValue(1);
                GlobalVar.bBorderless.ChangeValue(0);
                GlobalVar.bMaximizeWindow.ChangeValue(0);
            }
        }

        private void SetAnisotropic()
        {
            if(AnisotropicSetting.SelectedIndex == 0)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(1);
            }
            else if (AnisotropicSetting.SelectedIndex == 1)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(2);

            }
            else if (AnisotropicSetting.SelectedIndex == 2)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(4);

            }
            else if (AnisotropicSetting.SelectedIndex == 3)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(8);

            }
            else if (AnisotropicSetting.SelectedIndex == 4)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(12);

            }
            else if (AnisotropicSetting.SelectedIndex == 5)
            {
                GlobalVar.iMaxAnisotropy.ChangeValue(16);

            }
        }

        private void SetAntiAliasing()
        {
            if(Antianialising.SelectedIndex == 0)
            {
                GlobalVar.sAntiAliasing.ChangeValue(GlobalVar.sAntiAliasing_Off);
            }else if (Antianialising.SelectedIndex == 1)
            {
                GlobalVar.sAntiAliasing.ChangeValue(GlobalVar.sAntiAliasing_Low);
            }else if (Antianialising.SelectedIndex == 2)
            {
                GlobalVar.sAntiAliasing.ChangeValue(GlobalVar.sAntiAliasingHigh);
            }
        }

        private void SetResolution()
        {
            if (ratio169Selected)
            {
                if(Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Width.ChangeValue( 800);
                    GlobalVar.Resolution_Height.ChangeValue(450) ;
                }
                else if (Resolution_ComboBox.SelectedIndex == 1)
                {
                    GlobalVar.Resolution_Height.ChangeValue(720);
                    GlobalVar.Resolution_Width.ChangeValue(1280);
                }
                else if (Resolution_ComboBox.SelectedIndex == 2)
                {
                    GlobalVar.Resolution_Height.ChangeValue(810);
                    GlobalVar.Resolution_Width.ChangeValue(1440);
                }
                else if (Resolution_ComboBox.SelectedIndex == 3)
                {
                    GlobalVar.Resolution_Height.ChangeValue(1080);
                    GlobalVar.Resolution_Width.ChangeValue(1920);
                }
            }
            else if (ratio1610Selected)
            {
                if(Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(500);
                    GlobalVar.Resolution_Width.ChangeValue(800);
                }
                else if (Resolution_ComboBox.SelectedIndex == 1)
                {
                    GlobalVar.Resolution_Height.ChangeValue(640);
                    GlobalVar.Resolution_Width.ChangeValue(1024);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(800);
                    GlobalVar.Resolution_Width.ChangeValue(1280);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(900);
                    GlobalVar.Resolution_Width.ChangeValue(1440);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(1050);
                    GlobalVar.Resolution_Width.ChangeValue(1680);
                }
            }else if (!ratio1610Selected && !ratio169Selected)
            {
                if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(768);
                    GlobalVar.Resolution_Width.ChangeValue(1024);
                }
                else if (Resolution_ComboBox.SelectedIndex == 1)
                {
                    GlobalVar.Resolution_Height.ChangeValue(864);
                    GlobalVar.Resolution_Width.ChangeValue(1152);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(960);
                    GlobalVar.Resolution_Width.ChangeValue(1280);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(1050);
                    GlobalVar.Resolution_Width.ChangeValue(1400);
                }
                else if (Resolution_ComboBox.SelectedIndex == 0)
                {
                    GlobalVar.Resolution_Height.ChangeValue(1200);
                    GlobalVar.Resolution_Width.ChangeValue(1600);
                }
            }
        }

        private bool SetAmbientOcclusion()
        {
            if(Ambient_OClussion.SelectedIndex == 0)
            {
                GlobalVar.bSAOEnable.ChangeValue(GlobalVar.bSAOEnable_Off);
            }else if (Ambient_OClussion.SelectedIndex == 1)
            {
                GlobalVar.bSAOEnable.ChangeValue(GlobalVar.bSAOEnable_On);
            }
            return true;
        }

        private void SetDOFQuality()
        {
            if(DOF.SelectedIndex == 0)
            {
                GlobalVar.bDoDepthOfField.ChangeValue(GlobalVar.bDoDepthOfField_Low);
                GlobalVar.bScreenSpaceBokeh.ChangeValue(GlobalVar.bScreenSpaceBokeh_Low);
            }else if (DOF.SelectedIndex == 1)
            {
                GlobalVar.bDoDepthOfField.ChangeValue(GlobalVar.bDoDepthOfField_High);
                GlobalVar.bScreenSpaceBokeh.ChangeValue(GlobalVar.bScreenSpaceBokeh_High);
            }
        }

        private void SetGodRayQuality()
        {
            if(GodRays_Quality.SelectedIndex == 0)
            {
                GlobalVar.bVolumetricLightingEnable.ChangeValue(GlobalVar.bVolumetricLightingEnable_Off);
                GlobalVar.iVolumetricLightingQuality.ChangeValue(GlobalVar.iVolumetricLightingQuality_Low);
            }
            else if (GodRays_Quality.SelectedIndex == 1)
            {
                GlobalVar.bVolumetricLightingEnable.ChangeValue(GlobalVar.bVolumetricLightingEnable_On);
                GlobalVar.iVolumetricLightingQuality.ChangeValue(GlobalVar.iVolumetricLightingQuality_Low);

            }
            else if (GodRays_Quality.SelectedIndex == 2)
            {
                GlobalVar.bVolumetricLightingEnable.ChangeValue(GlobalVar.bVolumetricLightingEnable_On);
                GlobalVar.iVolumetricLightingQuality.ChangeValue(GlobalVar.iVolumetricLightingQuality_Medium);

            }
            else if (GodRays_Quality.SelectedIndex == 3)
            {
                GlobalVar.bVolumetricLightingEnable.ChangeValue(GlobalVar.bVolumetricLightingEnable_On);
                GlobalVar.iVolumetricLightingQuality.ChangeValue(GlobalVar.iVolumetricLightingQuality_High);

            }
            else if (GodRays_Quality.SelectedIndex == 4)
            {
                GlobalVar.bVolumetricLightingEnable.ChangeValue(GlobalVar.bVolumetricLightingEnable_On);
                GlobalVar.iVolumetricLightingQuality.ChangeValue(GlobalVar.iVolumetricLightingQuality_Ultra);
            }
        }

        private void SetLightingQuality()
        {
            if(Lighting_Quality.SelectedIndex == 0)
            {
                GlobalVar.bForceIgnoreSmoothness.ChangeValue(GlobalVar.bForceIgnoreSmoothness_Medium);
                GlobalVar.bScreenSpaceSubsurfaceScattering.ChangeValue(GlobalVar.bScreenSpaceSubsurfaceScattering_Low);
            }
            else if (Lighting_Quality.SelectedIndex == 1)
            {
                GlobalVar.bForceIgnoreSmoothness.ChangeValue(GlobalVar.bForceIgnoreSmoothness_High);
                GlobalVar.bScreenSpaceSubsurfaceScattering.ChangeValue(GlobalVar.bScreenSpaceSubsurfaceScattering_Low);

            }
            else
            if (Lighting_Quality.SelectedIndex == 2)
            {
                GlobalVar.bForceIgnoreSmoothness.ChangeValue(GlobalVar.bForceIgnoreSmoothness_High);
                GlobalVar.bScreenSpaceSubsurfaceScattering.ChangeValue(GlobalVar.bScreenSpaceSubsurfaceScattering_Ultra);

            }
        }

        private void SetDecalQuantity()
        {
            if(Decal_Quantity.SelectedIndex == 0)
            {
        //        GlobalVar.iMaxDecalsPerFrame.ChangeValue(GlobalVar.iMaxDecalsPerFrame_None);
                GlobalVar.bDecals.ChangeValue(GlobalVar.iMaxSkinDecalsPerFrame_None);
                GlobalVar.bSkinnedDecals.ChangeValue(GlobalVar.iMaxSkinDecalsPerFrame_None);
                GlobalVar.uMaxDecals.ChangeValue(GlobalVar.uMaxDecals_None);
            }
            else if (Decal_Quantity.SelectedIndex == 1)
            {
                GlobalVar.iMaxDecalsPerFrame.ChangeValue(GlobalVar.iMaxDecalsPerFrame_Medium);
                GlobalVar.iMaxSkinDecalsPerFrame.ChangeValue(GlobalVar.iMaxSkinDecalsPerFrame_Medium);
                GlobalVar.bDecals.ChangeValue(1);
                GlobalVar.bSkinnedDecals.ChangeValue(1);
                GlobalVar.uMaxDecals.ChangeValue(GlobalVar.uMaxDecals_Medium);
                GlobalVar.uMaxSkinDecals.ChangeValue(GlobalVar.uMaxSkinDecals_Medium);
                GlobalVar.uMaxSkinDecalsPerActor.ChangeValue(GlobalVar.uMaxSkinDecalsPerActor_Medium);

            }
            else if (Decal_Quantity.SelectedIndex == 2)
            {
                GlobalVar.iMaxDecalsPerFrame.ChangeValue(GlobalVar.iMaxDecalsPerFrame_High);
                GlobalVar.iMaxSkinDecalsPerFrame.ChangeValue(GlobalVar.iMaxSkinDecalsPerFrame_High);
                GlobalVar.bDecals.ChangeValue(1);
                GlobalVar.bSkinnedDecals.ChangeValue(1);
                GlobalVar.uMaxDecals.ChangeValue(GlobalVar.uMaxDecals_High);
                GlobalVar.uMaxSkinDecals.ChangeValue(GlobalVar.uMaxSkinDecals_High);
                GlobalVar.uMaxSkinDecalsPerActor.ChangeValue(GlobalVar.uMaxSkinDecalsPerActor_Ultra);

            }
            else if (Decal_Quantity.SelectedIndex == 3)
            {
                GlobalVar.iMaxDecalsPerFrame.ChangeValue(GlobalVar.iMaxDecalsPerFrame_High);
                GlobalVar.iMaxSkinDecalsPerFrame.ChangeValue(GlobalVar.iMaxSkinDecalsPerFrame_High);
                GlobalVar.bDecals.ChangeValue(1);
                GlobalVar.bSkinnedDecals.ChangeValue(1);
                GlobalVar.uMaxDecals.ChangeValue(GlobalVar.uMaxDecals_Ultra);
                GlobalVar.uMaxSkinDecals.ChangeValue(GlobalVar.uMaxSkinDecals_Ultra);
                GlobalVar.uMaxSkinDecalsPerActor.ChangeValue(GlobalVar.uMaxSkinDecalsPerActor_Ultra);
            }
        }

        private void SetShadowDistance()
        {
            if (Shadow_Distance.SelectedIndex == 0)
            {
                GlobalVar.fShadowDistance.ChangeValue(GlobalVar.fShadowDistance_Medium);
                GlobalVar.fDirShadowDistance.ChangeValue(GlobalVar.fDirShadowDistance_Medium);
                GlobalVar.iDirShadowSplits.ChangeValue(GlobalVar.iDirShadowSplits_Medium);
            }
            else
            if (Shadow_Distance.SelectedIndex == 1)
            {
                GlobalVar.fShadowDistance.ChangeValue(GlobalVar.fShadowDistance_High);
                GlobalVar.fDirShadowDistance.ChangeValue(GlobalVar.fDirShadowDistance_High);
                GlobalVar.iDirShadowSplits.ChangeValue(GlobalVar.iDirShadowSplits_Ultra);
            }
            else
            if (Shadow_Distance.SelectedIndex == 2)
            {
                GlobalVar.fShadowDistance.ChangeValue(GlobalVar.fShadowDistance_Ultra);
                GlobalVar.fDirShadowDistance.ChangeValue(GlobalVar.fDirShadowDistance_Ultra);
                GlobalVar.iDirShadowSplits.ChangeValue(GlobalVar.iDirShadowSplits_Ultra);
            }
        }

        private void SetShadowQuality()
        {
            if(Shadow_Quality.SelectedIndex == 0)
            {
                GlobalVar.ShadowQuality.ChangeValue(GlobalVar.ShadowQuality_VeryLow);
                GlobalVar.MaxFocusShadow.ChangeValue(GlobalVar.MaxFocusShadow_Low);
                GlobalVar.fBlendSplitDirShadow.ChangeValue(GlobalVar.fBlendSplitDirShadow_Low);
                GlobalVar.uiShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Low);
                GlobalVar.uiOrthoShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Low);
            }
            else if (Shadow_Quality.SelectedIndex == 1)
            {
                GlobalVar.ShadowQuality.ChangeValue(GlobalVar.ShadowQuality_Low);
                GlobalVar.MaxFocusShadow.ChangeValue(GlobalVar.MaxFocusShadow_Low);
                GlobalVar.fBlendSplitDirShadow.ChangeValue(GlobalVar.fBlendSplitDirShadow_Low);
                GlobalVar.uiShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Low);
                GlobalVar.uiOrthoShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Low);


            }
            else if (Shadow_Quality.SelectedIndex == 2)
            {
                GlobalVar.ShadowQuality.ChangeValue(GlobalVar.ShadowQuality_Medium);
                GlobalVar.MaxFocusShadow.ChangeValue(GlobalVar.MaxFocusShadow_Medium);
                GlobalVar.fBlendSplitDirShadow.ChangeValue(GlobalVar.fBlendSplitDirShadow_Medium);
                GlobalVar.uiShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Medium);
                GlobalVar.uiOrthoShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_Medium);
            }
            else if (Shadow_Quality.SelectedIndex == 3)
            {
                GlobalVar.ShadowQuality.ChangeValue(GlobalVar.ShadowQuality_High);
                GlobalVar.MaxFocusShadow.ChangeValue(GlobalVar.MaxFocusShadow_High);
                GlobalVar.fBlendSplitDirShadow.ChangeValue(GlobalVar.fBlendSplitDirShadow_High);
                GlobalVar.uiShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_High);
                GlobalVar.uiOrthoShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_High);


            }
            else if (Shadow_Quality.SelectedIndex == 4)
            {
                GlobalVar.ShadowQuality.ChangeValue(GlobalVar.ShadowQuality_Ultra);
                GlobalVar.MaxFocusShadow.ChangeValue(GlobalVar.MaxFocusShadow_High);
                GlobalVar.fBlendSplitDirShadow.ChangeValue(GlobalVar.fBlendSplitDirShadow_High);
                GlobalVar.uiShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_High);
                GlobalVar.uiOrthoShadowFilter.ChangeValue(GlobalVar.uiShadowFilter_High);
            }
        }

       private void SetTextureQuality()
        {
            if (Texture_Quality.SelectedIndex == 0)
            {
                GlobalVar.TextureQuality.ChangeValue(GlobalVar.TextureQualityLow);
            }
            else if (Texture_Quality.SelectedIndex == 1)
            {
                GlobalVar.TextureQuality.ChangeValue(GlobalVar.TextureQuality_Medium);
            }
            else if (Texture_Quality.SelectedIndex == 2)
            {
                GlobalVar.TextureQuality.ChangeValue(GlobalVar.TextureQuality_High);
            }
            else if (Texture_Quality.SelectedIndex == 3)
            {
                GlobalVar.TextureQuality.ChangeValue(GlobalVar.TextureQuality_Ultra);
            }
        }


        #endregion

        private void ObjectFade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ObjectFade_Text.Text = ObjectFade.Value.ToString();
        }

        private void ActorFade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ActorFade_Text.Text = ActorFade.Value.ToString();
        }

        private void GrassFade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            GrassFade_Text.Text = GrassFade.Value.ToString();
        }

        private void ItemFade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ItemFade_Text.Text = ItemFade.Value.ToString();
        }
    }
}
