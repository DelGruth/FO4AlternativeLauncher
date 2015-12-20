using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniReader;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using Microsoft.Win32;
using System.Data;

namespace FO4AlternativeLauncher.Common
{


    public class VarContainer
    {
        //order matters from 0->100
        // public List<string> VarSection;
        public List<string> VarName
        {
            get; set;
        }
        public List<string> VarValue
        {
            get; set;
        }
        //from low to high element index,must be tied to other index
        public List<int> VarVisualElementIndexByValue
        {
            get; set;
        }

    }

    //use this
    public class VisualSettingConverter
    {
        //possible Setting value,must be tied to possible selected index
        public static List<string> SettingValue;

        public VisualSettingConverter(string[] settingValue, int[] visualIndex)
        {
            SettingValue = new List<string>(settingValue.Length);
            SettingValue.AddRange(settingValue);
        }

        public void ChangeValue(AppSettingFormat s, int i)
        {
            s.ChangeValue(SettingValue[i]);

        }

    }


    public class GlobalVar
    {

        public GlobalVar()
        {

        }
        #region Depricated
        /*    public const string nonLauncherSettingsFile = @"./CustomVar.xml";
                public static List<SettingContainer> CustomDefinedSettings = new List<SettingContainer>();
                
    public class SettingContainer
    {
        public List<VarContainer> SettingVariables
        {
            get; set;
        }
        public string SettingName { get; set; }
        public string VarElementName
        {
            get; set;
        }
        public string SettingDescription
        {
            get; set;
        }
        public SettingContainer()
        {
            SettingVariables = new List<VarContainer>();
        }
    }

            public static void ReadNonLauncherSettings()
                {
                    if (File.Exists(nonLauncherSettingsFile))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(SettingContainer));
                        XmlReader reader = XmlReader.Create(nonLauncherSettingsFile);
                        xml.CanDeserialize(reader);
                        CustomDefinedSettings = (List<SettingContainer>)xml.Deserialize(reader);
                    }
            }
        */
        #endregion

        List<AppSettingFormat> AllAppSettings = new List<AppSettingFormat>() { OpenConsole };


        static string AppSettingPath = "./FO4Alternativelauncher/AppSettings.ini";
        #region Custom Settings
        public static AppSettingFormat Vsync = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iPresentInterval",
            VarValue = 1.ToString()
        };

        public static AppSettingFormat FOV_1st = new AppSettingFormat()
        {
            Section = "Interface",
            VarName = "fDefault1stPersonFOV",
            VarValue = "90",
            pref = false

        }; public static AppSettingFormat FOV_3rd = new AppSettingFormat()
        {
            Section = "Interface",
            VarName = "fDefaultWorldFOV",
            VarValue = "90",
            pref = false

        };
        public static AppSettingFormat MaxParticles = new AppSettingFormat()
        {
            Section = "Particles",
            VarName = "iMaxDesired",
            VarValue = "999"
        };
        public static AppSettingFormat ObjectFade = new AppSettingFormat()
        {
            Section = "LOD",
            VarName = "fLODFadeOutMultObjects",
            VarValue = "30"
        }; public static AppSettingFormat ActorFade = new AppSettingFormat()
        {
            Section = "LOD",
            VarName = "fLODFadeOutMultActors",
            VarValue = "15"
        }; public static AppSettingFormat ItemFade = new AppSettingFormat()
        {
            Section = "LOD",
            VarName = "fLODFadeOutMultItems",
            VarValue = "10"
        };
        public static AppSettingFormat GrassFade = new AppSettingFormat()
        {
            Section = "Grass",
            VarName = "fGrassStartFadeDistance",
            VarValue = "7000"
        };



        public static AppSettingFormat iNumHWThreads = new AppSettingFormat()
        {
            Section = "General",
            VarName = "iNumHWThreads",
            VarValue = 4.ToString(),
            pref = false

        }; public static AppSettingFormat iNumThreads = new AppSettingFormat()
        {
            Section = "HAVOK",
            VarName = "iNumThreads",
            VarValue = 1.ToString(),
            pref = false

        };
        public static AppSettingFormat iMinGrassSize = new AppSettingFormat()
        {
            Section = "Grass",
            VarName = "iMinGrassSize",
            VarValue = 20.ToString(),
            pref = false

        };
        public static AppSettingFormat bAllowCreateGrass = new AppSettingFormat()
        {
            Section = "Grass",
            VarName = "bAllowCreateGrass",
            VarValue = 1.ToString(),
            pref = false,

        };
        public static AppSettingFormat bAllowLoadGrass = new AppSettingFormat()
        {
            Section = "Grass",
            VarName = "bAllowLoadGrass",
            VarValue = 0.ToString(),
            pref = false
        };
        public static AppSettingFormat iMaxGrassTypesPerTexure = new AppSettingFormat()
        {
            Section = "Grass",
            VarName = "iMaxGrassTypesPerTexure",
            VarValue = 15.ToString(),
            pref = false


        };

        public static AppSettingFormat SkipIntro = new AppSettingFormat()
        {
            Section = "General",

            //  sIntroSequence = GameIntro_V3_B.bk2
            VarName = "sIntroSequence",
            VarValue = " ",
            pref = false,
            vsc = new global::VisualSettingConverter(new string[2]
            {
                "GameIntro_V3_B.bk2"," "
            }, new int[2] {
                0,1

            })
        };

        public static AppSettingFormat bShowTutorials = new AppSettingFormat()
        {
            Section = "Interface",
            VarName = "bShowTutorials",
            VarValue = 0.ToString(),
            pref = false,
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 })
        };
        public static AppSettingFormat bEnableAnalytics = new AppSettingFormat()
        {
            Section = "Bethesda.net",
            VarName = "bEnableAnalytics",
            VarValue = 0.ToString(),
            pref = false,
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 })

        }; public static AppSettingFormat bEnablePlatform = new AppSettingFormat()
        {
            Section = "Bethesda.net",
            VarName = "bEnablePlatform",
            VarValue = 0.ToString(),
            pref = false,
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 })

        }; public static AppSettingFormat bMaximizeWindow = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bMaximizeWindow",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 })

        };
        public static AppSettingFormat bMultiThreadedRendering = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bMultiThreadedRendering",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bEssentialTakeNoDamage = new AppSettingFormat()
        {
            Section = "Gameplay",
            VarName = "bEssentialTakeNoDamage",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bDisableAllGore = new AppSettingFormat()
        {
            Section = "General",
            VarName = "bDisableAllGore",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bGamepadEnable = new AppSettingFormat()
        {
            Section = "General",
            VarName = "bGamepadEnable",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
        }; public static AppSettingFormat bCrosshairEnabled = new AppSettingFormat()
        {
            Section = "MAIN",
            VarName = "bCrosshairEnabled",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
        }; public static AppSettingFormat fAutosaveEveryXMins = new AppSettingFormat()
        {
            Section = "SaveGame",
            VarName = "fAutosaveEveryXMins",
            VarValue = 10.0000.ToString(),
        };
        public static AppSettingFormat f3rdPersonAimFOV = new AppSettingFormat()
        {
            Section = "Camera",
            VarName = "f3rdPersonAimFOV",
            VarValue = 50.0000.ToString(),
            pref = false
        };
        public static AppSettingFormat bForceNPCsUseAmmo = new AppSettingFormat()
        {
            Section = "Combat",
            VarName = "bForceNPCsUseAmmo",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat iDefaultWaitHours = new AppSettingFormat()
        {
            Section = "Interface",
            VarName = "iDefaultWaitHours",
            VarValue = 1.ToString(),
            pref = false
        }; public static AppSettingFormat bBackgroundPathing = new AppSettingFormat()
        {
            Section = "Pathfinding",
            VarName = "bBackgroundPathing",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bBackgroundCellLoads = new AppSettingFormat()
        {
            Section = "BackgroundLoad",
            VarName = "bBackgroundCellLoads",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bBackgroundNavmeshUpdate = new AppSettingFormat()
        {
            Section = "BackgroundLoad",
            VarName = "bBackgroundNavmeshUpdate",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bUseThreadedParticleSystem = new AppSettingFormat()
        {
            Section = "General",
            VarName = "bUseThreadedParticleSystem",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bUseMultiThreadedTrees = new AppSettingFormat()
        {
            Section = "BackgroundLoad",
            VarName = "bUseMultiThreadedTrees",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        #region Don't add
        public static AppSettingFormat fUpdateBudgetMS = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "fUpdateBudgetMS",
            VarValue = 1.2.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat fExtraTaskletBudgetMS = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "fExtraTaskletBudgetMS",
            VarValue = 1.2.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat fPostLoadUpdateTimeMS = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "fExtraTaskletBudgetMS",
            VarValue = 500.0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat iMinMemoryPageSize = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "iMinMemoryPageSize",
            VarValue = 128.0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat iMaxMemoryPageSize = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "iMaxMemoryPageSize",
            VarValue = 512.0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat iMaxAllocatedMemoryBytes = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "iMaxAllocatedMemoryBytes",
            VarValue = 153600.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bEnableLogging = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "iMaxAllocatedMemoryBytes",
        }; public static AppSettingFormat bBloodSplatterEnabled = new AppSettingFormat()
        {
            Section = "ScreenSplatter",
            VarName = "bBloodSplatterEnabled",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat bUseBackgroundFileLoader = new AppSettingFormat()
        {
            Section = "BackgroundLoad",
            VarName = "bUseBackgroundFileLoader",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat bEnableProfiling = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "bEnableProfiling",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        public static AppSettingFormat bEnableTrace = new AppSettingFormat()
        {
            Section = "Papyrus",
            VarName = "bEnableTrace",
            VarValue = 0.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        };
        #endregion


        public static AppSettingFormat bUseCompanionWarping = new AppSettingFormat()
        {
            Section = "Pathfinding",
            VarName = "bUseCompanionWarping",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "0", "1" }, new int[2] { 0, 1 }),
            pref = false
        }; public static AppSettingFormat uGridsToLoad = new AppSettingFormat()
        {
            Section = "General",
            VarName = "uGridsToLoad",
            VarValue = 5.ToString(),
            vsc = new global::VisualSettingConverter(new string[7] {"1","3", "5", "7", "9", "11", "13" }, new int[5] { 0, 1, 2, 3, 4 }),
        };
        public static AppSettingFormat uExteriorCellBuffer = new AppSettingFormat()
        {
            pref =false,
            Section = "General",
            VarName = "uExterior Cell Buffer",
            VarValue = 36.ToString(),
            vsc = new global::VisualSettingConverter(new string[7] {"4","16", "36", "64", "100", "144", "196" }, new int[5] { 0, 1, 2, 3, 4 }),
        }; public static AppSettingFormat iPreloadSizeLimit = new AppSettingFormat()
        {
            pref =false,
            Section = "General",
            VarName = "iPreloadSizeLimit",
            VarValue = 419430400.ToString(),
            vsc = new global::VisualSettingConverter(new string[7] { "1048576", "9437184","26214400", "51380224", "84934656", "126877696", "177209344" }, new int[5] { 0, 1, 2, 3, 4 }),
        }; public static AppSettingFormat fChancesToPlayAlternateIntro = new AppSettingFormat()
        {
            pref =false,
            Section = "General",
            VarName = "fChancesToPlayAlternateIntro",
            VarValue = 1.ToString(),
            vsc = new global::VisualSettingConverter(new string[2] { "1", "0", }, new int[2] { 0, 1}),
        };
        





        #endregion

   


        public const int Vsync_Off = 0;
        public const int Vsync_On = 1;
        public const int iMinGrassSize_Off = 0;
        public const int iMinGrassSize_Low = 80;
        public const int iMinGrassSize_Medium = 40;
        public const int iMinGrassSize_High = 20;
        public const int iMinGrassSize_VeryHigh = 10;
        public const int iMinGrassSize_Ultra = 1;



        #region Application Settings
        //Applications Settings
        public static AppSettingFormat OpenConsole = new AppSettingFormat()
        {
            Section = "Main",
            VarName = "ConsoleOpen",
            VarValue = 0.ToString()
        };
        public static AppSettingFormat EXEPath = new AppSettingFormat()
        {
            Section = "Main",
            VarName = "EXEPath",
        };

        public static AppSettingFormat Fallout4IniFolder = new AppSettingFormat()
        {
            VarValue = "um"
        };
        #endregion


        #region Fallout4 Settings
        public static AppSettingFormat TextureQuality = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iTexMipMapSkip",
            VarValue = 2.ToString(),
        };
        public static AppSettingFormat ShadowQuality = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iShadowMapResolution",
            VarValue = 4096.ToString(),
        };
        public static AppSettingFormat MaxFocusShadow = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iMaxFocusShadows",
            VarValue = "4"
        };
        public static AppSettingFormat fBlendSplitDirShadow = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "fBlendSplitDirShadow",
            VarValue = "4"
        };

        public static AppSettingFormat uiShadowFilter = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "uiShadowFilter",
            VarValue = "3"
        };
        public static AppSettingFormat uiOrthoShadowFilter = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "uiOrthoShadowFilter",
            VarValue = "3"
        };
        public static AppSettingFormat fShadowDistance = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "fShadowDistance",
            VarValue = "20000"
        };
        public static AppSettingFormat fDirShadowDistance = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "fDirShadowDistance",
            VarValue = "20000"
        };
        public static AppSettingFormat iDirShadowSplits = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iDirShadowSplits",
            VarValue = 3.ToString()
        };
        public static AppSettingFormat iMaxDecalsPerFrame = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iMaxDecalsPerFrame",
            VarValue = 100.ToString()
        };
        public static AppSettingFormat iMaxSkinDecalsPerFrame = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iMaxSkinDecalsPerFrame",
            VarValue = 25.ToString()
        };
        public static AppSettingFormat bDecals = new AppSettingFormat()
        {
            Section = "Decals",
            VarName = "bDecals",
            VarValue = "1"
        }; public static AppSettingFormat bSkinnedDecals = new AppSettingFormat()
        {
            Section = "Decals",
            VarName = "bSkinnedDecals",
            VarValue = "1"
        };
        public static AppSettingFormat uMaxDecals = new AppSettingFormat()
        {
            Section = "Decals",
            VarName = "uMaxDecals",
            VarValue = "1000"
        };
        public static AppSettingFormat uMaxSkinDecals = new AppSettingFormat()
        {
            Section = "Decals",
            VarName = "uMaxSkinDecals",
            VarValue = "100"
        };
        public static AppSettingFormat uMaxSkinDecalsPerActor = new AppSettingFormat()
        {
            Section = "Decals",
            VarName = "uMaxSkinDecalsPerActor",
            VarValue = 40.ToString()
        };
        public static AppSettingFormat bForceIgnoreSmoothness = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bForceIgnoreSmoothness",
            VarValue = 0.ToString()
        };
        public static AppSettingFormat bScreenSpaceSubsurfaceScattering = new AppSettingFormat()
        {
            Section = "LightingShader",
            VarName = "bScreenSpaceSubsurfaceScattering",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat bVolumetricLightingEnable = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bVolumetricLightingEnable",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat iVolumetricLightingQuality = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iVolumetricLightingQuality",
            VarValue = 3.ToString()
        };
        public static AppSettingFormat bDoDepthOfField = new AppSettingFormat()
        {
            Section = "Imagespace",
            VarName = "bDoDepthOfField",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat bScreenSpaceBokeh = new AppSettingFormat()
        {
            Section = "Imagespace",
            VarName = "bScreenSpaceBokeh",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat bSAOEnable = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bSAOEnable",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat Resolution_Width = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iSize W",
            VarValue = "1920"
        }; public static AppSettingFormat Resolution_Height = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iSize H",
            VarValue = "1080"
        };
        public static AppSettingFormat sAntiAliasing = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "sAntiAliasing",
            VarValue = " "
        };
        public static AppSettingFormat iMaxAnisotropy = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "iMaxAnisotropy",
            VarValue = "16"
        };
        public static AppSettingFormat bFull_Screen = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bFull Screen",
            VarValue = "1"
        }; public static AppSettingFormat bBorderless = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bBorderless",
            VarValue = "1"
        };
        public static AppSettingFormat bScreenSpaceReflections = new AppSettingFormat()
        {
            Section = "LightingShader",
            VarName = "bScreenSpaceReflections",
            VarValue = 1.ToString()
        };
        public static AppSettingFormat bEnableWetnessMaterials = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bEnableWetnessMaterials",
            VarValue = 0.ToString()
        };
        public static AppSettingFormat bEnableRainOcclusion = new AppSettingFormat()
        {
            Section = "Display",
            VarName = "bEnableRainOcclusion",
            VarValue = 0.ToString()
        };

        public static AppSettingFormat bMBEnable = new AppSettingFormat()
        {
            Section = "Imagespace",
            VarName = "bMBEnable",
            VarValue = 0.ToString()
        };

        public static AppSettingFormat bLensFlare = new AppSettingFormat()
        {
            Section = "Imagespace",
            VarName = "bLensFlare",
            VarValue = 0.ToString()
        };
   
        #endregion end fallout4 settings

        #region Fallout4 Launcher Default values
        public static int AspectRatio_169 = 0;
        public static int AspectRatio1610 = 1;
        public const int TextureQualityLow = 2;
        public const int TextureQuality_Medium = 1;
        public const int TextureQuality_High = 0;
        public const int TextureQuality_Ultra = 0;
        //    public const int ShadowQuality_UltraLow = 124;
        public const int ShadowQuality_VeryLow = 512;
        public const int ShadowQuality_Low = 1024;
        public const int ShadowQuality_Medium = 2048;
        public const int ShadowQuality_High = 2048;
        public const int ShadowQuality_Ultra = 4096;
        public const int MaxFocusShadow_Low = 1;
        public const int MaxFocusShadow_Medium = 2;
        public const int MaxFocusShadow_High = 4;
        public const int fBlendSplitDirShadow_Low = 0;
        public const int fBlendSplitDirShadow_Medium = 2;
        public const int fBlendSplitDirShadow_High = 48;
        public const int uiShadowFilter_Low = 1;
        public const int uiShadowFilter_Medium = 2;
        public const int uiShadowFilter_High = 3;
        public const int uiOrthoShadowFilter_Low = 1;
        public const int uiOrthoShadowFilter_Medium = 2;
        public const int uiOrthoShadowFilter_High = 3;
        public const int fShadowDistance_Medium = 3000;
        public const int fShadowDistance_High = 14000;
        public const int fShadowDistance_Ultra = 20000;
        public const int fDirShadowDistance_Medium = 3000;
        public const int fDirShadowDistance_High = 14000;
        public const int fDirShadowDistance_Ultra = 20000;
        public const int iDirShadowSplits_Medium = 2;
        public const int iDirShadowSplits_Ultra = 3;
        public const int iMaxDecalsPerFrame_None = 0;
        public const int iMaxDecalsPerFrame_Medium = 25;
        public const int iMaxDecalsPerFrame_High = 100;
        public const int iMaxSkinDecalsPerFrame_None = 0;
        public const int iMaxSkinDecalsPerFrame_Medium = 3;
        public const int iMaxSkinDecalsPerFrame_High = 25;
        public const int uMaxDecals_None = 0;
        public const int uMaxDecals_Medium = 100;
        public const int uMaxDecals_High = 250;
        public const int uMaxDecals_Ultra = 1000;
        public const int uMaxSkinDecals_Medium = 35;
        public const int uMaxSkinDecals_High = 50;
        public const int uMaxSkinDecals_Ultra = 100;
        public const int uMaxSkinDecalsPerActor_Medium = 20;
        public const int uMaxSkinDecalsPerActor_Ultra = 40;
        public const int bForceIgnoreSmoothness_Medium = 1;
        public const int bForceIgnoreSmoothness_High = 0;
        public const int bScreenSpaceSubsurfaceScattering_Low = 0;
        public const int bScreenSpaceSubsurfaceScattering_Ultra = 1;
        public const int bVolumetricLightingEnable_Off = 0;
        public const int bVolumetricLightingEnable_On = 1;
        public const int iVolumetricLightingQuality_Low = 0;
        public const int iVolumetricLightingQuality_Medium = 1;
        public const int iVolumetricLightingQuality_High = 2;
        public const int iVolumetricLightingQuality_Ultra = 3;
        public const int bDoDepthOfField_Low = 1;
        public const int bDoDepthOfField_High = 1;
        public const int bScreenSpaceBokeh_Low = 0;
        public const int bScreenSpaceBokeh_High = 1;
        public const int bSAOEnable_Off = 0;
        public const int bSAOEnable_On = 1;
        public const string sAntiAliasing_Off = " ";
        public const string sAntiAliasing_Low = "FXAA";
        public const string sAntiAliasingHigh = "TAA";



        #endregion


        public List<GenericIniSetting> GenericSettings = new List<GenericIniSetting>();
        public readonly List<AppSettingFormat> AllFalloutSettings = new List<AppSettingFormat>()
        {       TextureQuality, ShadowQuality, iMaxAnisotropy,  sAntiAliasing, Resolution_Height, Resolution_Width, bSAOEnable,
                bScreenSpaceBokeh, bDoDepthOfField, iVolumetricLightingQuality, bVolumetricLightingEnable, bScreenSpaceSubsurfaceScattering,
                bForceIgnoreSmoothness, uMaxSkinDecalsPerActor, uMaxSkinDecals, uMaxDecals, bSkinnedDecals, bDecals,
                iMaxSkinDecalsPerFrame, iMaxDecalsPerFrame, iDirShadowSplits, fDirShadowDistance, fDirShadowDistance,
                fShadowDistance, uiOrthoShadowFilter, uiShadowFilter, fBlendSplitDirShadow, MaxFocusShadow, bLensFlare,
                bMBEnable, bEnableRainOcclusion, bEnableWetnessMaterials, bScreenSpaceReflections, bBorderless, bFull_Screen
                ,Vsync,FOV_1st,FOV_3rd,MaxParticles,ObjectFade,ActorFade,ItemFade,GrassFade,iNumHWThreads,iNumThreads,
                iMinGrassSize, bAllowCreateGrass,bAllowLoadGrass,iMaxGrassTypesPerTexure,SkipIntro ,bEnablePlatform
                ,bEnableAnalytics,bShowTutorials,bMaximizeWindow,bMultiThreadedRendering,bEssentialTakeNoDamage,bDisableAllGore,
                bGamepadEnable,bCrosshairEnabled,fAutosaveEveryXMins,f3rdPersonAimFOV,bForceNPCsUseAmmo,iDefaultWaitHours,
                bUseThreadedParticleSystem,bUseCompanionWarping,uGridsToLoad,uExteriorCellBuffer,iPreloadSizeLimit,fChancesToPlayAlternateIntro
               ,bUseBackgroundFileLoader,bBloodSplatterEnabled };

 
        //Depricated
        public  void ReadCustomValues()
        {

            //if (File.Exists("./FO4Alternativelauncher/GenericIniSettings.xml"))
            //{
            //    XmlSerializer ser = new XmlSerializer(typeof(List<GenericIniSetting>));
            //    XmlReader reader = XmlReader.Create("./FO4Alternativelauncher/GenericIniSettings.xml");
            //    GenericSettings = (List<GenericIniSetting>)ser.Deserialize(reader);
            //    reader.Dispose();
            //}
            //else
            //{
            //    SettingsEditor.Class1 net = new SettingsEditor.Class1();
            //    net.Serliaize();
            //    XmlSerializer ser = new XmlSerializer(typeof(List<GenericIniSetting>));
            //    XmlReader reader = XmlReader.Create("./FO4Alternativelauncher/GenericIniSettings.xml");
            //    GenericSettings = (List<GenericIniSetting>)ser.Deserialize(reader);
            //    reader.Dispose();
            //}
        }

        public static void ReadApplicationIni()
        {
            IniFile settingFile = new IniFile(AppSettingPath);
            if (settingFile.KeyExists(OpenConsole.VarName, "Main"))
            {
                OpenConsole.VarValue = settingFile.Read(OpenConsole.VarName, OpenConsole.Section);
            }
            if (settingFile.KeyExists("EXEPath", "Main"))
            {
                EXEPath.ChangeValue(settingFile.Read("EXEPath", "Main"));
            }
            else if (MainWindow.exeIndex != -1)
            {
                EXEPath.ChangeValue(MainWindow.PossibleFallout4Paths[MainWindow.exeIndex]);
            }
            else
            {
                try
                {
                    EXEPath.ChangeValue(Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\bethesda softworks\Fallout4\").GetValue("Installed Path").ToString() + "Fallout4.exe");
                    return;
                }
                catch
                {
                    MessageBox.Show("Could not determine path to Fallout4.exe,please set it manually at the launcher tab");
                }
            }
            MainWindow.Console.WriteToConsole("OpenConsoleValue is: " + OpenConsole.VarValue.ToString());
        }


        public static void WriteDefaultIni()
        {
            if (!Directory.Exists("./FO4Alternativelauncher"))
                Directory.CreateDirectory("./FO4Alternativelauncher");

            IniFile settingFile = new IniReader.IniFile(AppSettingPath);
            settingFile.Write(OpenConsole.VarName, (Convert.ToInt32(OpenConsole.VarValue)).ToString(), OpenConsole.Section);
            settingFile.Write(EXEPath.VarName, EXEPath.VarValue.ToString(), EXEPath.Section);
            return;

        }

        //Returns the fallout 4 settings directory
        public string GetIniFolder()
        {
            if (File.Exists(MainWindow.PossibleIniFilePaths[MainWindow.filePathIndex] + "Fallout4.ini"))
            {
                MainWindow.Console.WriteToConsole(MainWindow.PossibleIniFilePaths[MainWindow.filePathIndex]);
                return MainWindow.PossibleIniFilePaths[MainWindow.filePathIndex];
            }
            else if (File.Exists(Fallout4IniFolder.VarValue + "Fallout4.ini") && Fallout4IniFolder.VarValue != "um")
            {
                MainWindow.Console.WriteToConsole(Fallout4IniFolder.VarValue);
                return Fallout4IniFolder.VarValue;
            }
            else
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                dlg.Filter = "Fallout4.ini";
                dlg.CheckFileExists = true;
                dlg.CheckPathExists = true;

                if (dlg.ShowDialog() == true)
                {
                    GlobalVar.Fallout4IniFolder.ChangeValue(Path.GetDirectoryName(dlg.FileName));
                    MainWindow.Console.WriteToConsole("Changed fallout4 ini value: " + dlg.FileName);

                    if (File.Exists(Fallout4IniFolder + "/Fallout4.ini"))
                    {
                        return dlg.FileName;

                    }
                    else
                    {
                        MessageBox.Show("Could not locate Fallout4.ini,now closing application");
                        Environment.Exit(2);
                    }
                }

            }
            return null;
        }

        public void WriteAdvancedIniSettings(DataSet data)
        {

        }

        public void WriteFallout4PrefIni(string s = "none")
        {
            string iniFolfder = GetIniFolder();
            if (s == "none")
            {
                IniFile fallout4ini = new IniFile(iniFolfder + "Fallout4.ini");
                IniFile fallout4pref = new IniFile(iniFolfder + "Fallout4Prefs.ini");


                for (int i = 0; i < AllFalloutSettings.Count; i++)
                {
                    if (AllFalloutSettings[i].pref)
                    {
                        fallout4pref.Write(AllFalloutSettings[i].VarName, AllFalloutSettings[i].VarValue, AllFalloutSettings[i].Section);
                    }
                    else
                    {
                        fallout4ini.Write(AllFalloutSettings[i].VarName, AllFalloutSettings[i].VarValue, AllFalloutSettings[i].Section);

                    }
                }
            }
            else
            {
                if (!Directory.Exists("./Profiles/"))
                {
                    Directory.CreateDirectory("./Profiles/");
                }

                XmlWriter xl = XmlWriter.Create(s, new XmlWriterSettings { Indent = true });

                XmlSerializer file = new XmlSerializer(typeof(List<AppSettingFormat>), "test");
                file.Serialize(xl, AllFalloutSettings);
                xl.Dispose();

            }

        }

        public bool ReadFallout4PrefIni(string s = "none")
        {
            string iniFolfder = GetIniFolder();

            if (File.Exists(iniFolfder + "Fallout4Prefs.ini"))
            {
                if (s == "none")
                {

                    IniFile fallout4Custom = new IniFile(iniFolfder + "Fallout4Prefs.ini");
                    IniFile fallout4ini = new IniFile(iniFolfder + "Fallout4.ini");
                   // ReadCustomValues();
                    for (int i = 0; i < AllFalloutSettings.Count; i++)
                    {
                        if (AllFalloutSettings[i].pref)
                        {
                            if (fallout4Custom.KeyExists(AllFalloutSettings[i].VarName, AllFalloutSettings[i].Section))
                            {
                                AllFalloutSettings[i].ChangeValue(fallout4Custom.Read(AllFalloutSettings[i].VarName, AllFalloutSettings[i].Section));
                                MainWindow.Console.WriteToConsole("AntiAliasing value " + GlobalVar.sAntiAliasing.VarValue);

                            }
                        }
                        else
                        {
                            if (fallout4ini.KeyExists(AllFalloutSettings[i].VarName, AllFalloutSettings[i].Section))
                            {
                                AllFalloutSettings[i].ChangeValue(fallout4ini.Read(AllFalloutSettings[i].VarName, AllFalloutSettings[i].Section));
                                MainWindow.Console.WriteToConsole("AntiAliasing value " + GlobalVar.sAntiAliasing.VarValue);

                            }
                        }
                    }
                }
                else
                {
                    //   GenerateXMLAttributes
                    XmlReader xl = XmlReader.Create(s);

                    XmlSerializer file = new XmlSerializer(typeof(List<AppSettingFormat>), "test");
                    List<AppSettingFormat> FileFalloutSettings = new List<AppSettingFormat>();
                    FileFalloutSettings = (List<AppSettingFormat>)file.Deserialize(xl);
                    for (int i = 0; i < AllFalloutSettings.Count; i++)
                    {
                        AllFalloutSettings[i].ChangeValue(FileFalloutSettings[i].VarValue);
                    }
                    xl.Dispose();
                }
                
                ReadApplicationIni();
                return true;
            }
            ReadApplicationIni();
            return false;
        }
    }
}



    

