using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrivateSpoofer.Helper
{
    public class Spoofer
    {


        public static void CleanTraces()
        {
            string LocalLowFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow");
            string RoamingFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            if (Directory.Exists(RoamingFolder + @"/Unity"))
            {
                DirectoryInfo Unity = new(RoamingFolder + @"/Unity");
                Helper.DeleteDirectory(Unity);
            }

            if (Directory.Exists(LocalLowFolder + @"/Unity"))
            {
                DirectoryInfo Unity = new(LocalLowFolder + @"/Unity");
                Helper.DeleteDirectory(Unity); ;
            }

            if (Directory.Exists(LocalLowFolder + @"/VRChat"))
            {
                DirectoryInfo VRChat = new(LocalLowFolder + @"/VRChat");
                Helper.DeleteDirectory(VRChat);
            }

            RegistryKey CurrentUserReg = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64);
            CurrentUserReg.OpenSubKey("Software", true).DeleteSubKeyTree("VRChat", false);
            CurrentUserReg.OpenSubKey("Software", true).DeleteSubKeyTree("Unity", false);
            CurrentUserReg.OpenSubKey("Software", true).DeleteSubKeyTree("Unity Technologies", false);
            Helper.RunAsProcess("del / q / f / s % TEMP %\\*");


            CurrentUserReg.Close();
        }
        public static void SetComputerName()
        {
            string newName = Helper.RandomString(7);
            RegistryKey key = Registry.LocalMachine;

            string activeComputerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
            RegistryKey activeCmpName = key.CreateSubKey(activeComputerName);
            activeCmpName.SetValue("ComputerName", newName);
            activeCmpName.Close();
            string computerName = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName";
            RegistryKey cmpName = key.CreateSubKey(computerName);
            cmpName.SetValue("ComputerName", newName);
            cmpName.Close();
            string _hostName = "SYSTEM\\CurrentControlSet\\services\\Tcpip\\Parameters\\";
            RegistryKey hostName = key.CreateSubKey(_hostName);
            hostName.SetValue("Hostname", newName);
            hostName.SetValue("NV Hostname", newName);
            hostName.Close();

        }
        public static void ValorantCleanFull()
        {
            Helper.RunAsProcess(@" sc delete vgc
sc delete vgk
del ""C:\Windows\win.ini""
del ""C:\Riot Games\VALORANT\live\Manifest_NonUFSFiles_Win64.txt""
del ""C:\Users\Public\Desktop\VALORANT.Ink""
del ""C:\WINDOWS\Prefetch\VALORANT.EXE-B4BC886D.pf""
del ""C:\WINDOWS\Prefetch\VALORANT-WIN64-SHIPPING.EXE-D4EB2DF4.pf""
del ""C:\WINDOWS\Prefetch\INSTALL VALORANT.EXE-985FA96C.pf""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.product_settings.yaml""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.ok""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.manifest""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.lockfile""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.ico""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live\valorant.live.db""
del ""C:\ProgramData\Riot Games\Metadata\valorant.live""
@rd /S /Q ""C:\ProgramData\Riot Games\Metadata\valorant.live""
del ""C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Riot Games\VALORANT.INK""
del ""C:\Riot Games\VALORANT\live\Engine\Binaries\ThirdParty\CEF3\Win64\icudtl.dat""
del ""C:\Riot Games\Riot Client\UX\Plugins\plugin-manifest.json""
del ""C:\Riot Games\Riot Client\UX\icudtl.dat""
del ""C:\Riot Games\Riot Client\UX\natives_blob.bin""
del ""C:\Users\%username%\AppData\Local\Microsoft\Vault\UserProfileRoaming\Latest.dat""
del ""C:\Users\%username%\AppData\Local\AC\INetCookies\ESE\container.dat""
del ""C:\Users\%username%\AppData\Local\UnrealEngine\4.23\Saved\Config\WindowsClient\Manifest.ini""
del ""C:\Users\%username%\AppData\Local\Microsoft\OneDrive\logs\Common\DeviceHealthSummaryConfiguration.ini""
del ""C:\ProgramData\Microsoft\Windows\DeviceMetadataCache\dmrc.idx""
del ""C:\Users\%username%\ntuser.ini""
del ""C:\Users\%username%\ntuser.dat""
del ""C:\Users\%username%\AppData\Local\Microsoft\Windows\INetCache\IE\container.dat""
del ""D:\Windows\win.ini""
del ""D:\Riot Games\VALORANT\live\Manifest_NonUFSFiles_Win64.txt""
del ""D:\Riot Games\VALORANT\live\Engine\Binaries\ThirdParty\CEF3\Win64\icudtl.dat""
del ""D:\Riot Games\Riot Client\UX\Plugins\plugin-manifest.json""
del ""D:\Riot Games\Riot Client\UX\icudtl.dat""
del ""D:\Riot Games\Riot Client\UX\natives_blob.bin""
del ""D:\Users\%username%\AppData\Local\Microsoft\Vault\UserProfileRoaming\Latest.dat""
del ""D:\Users\%username%\AppData\Local\AC\INetCookies\ESE\container.dat""
del ""D:\Users\%username%\AppData\Local\UnrealEngine\4.23\Saved\Config\WindowsClient\Manifest.ini""
del ""D:\Users\%username%\AppData\Local\Microsoft\OneDrive\logs\Common\DeviceHealthSummaryConfiguration.ini""
del ""D:\ProgramData\Microsoft\Windows\DeviceMetadataCache\dmrc.idx""
del ""D:\Users\%username%\ntuser.ini""
del ""D:\Users\%username%\ntuser.dat""
del ""D:\Users\%username%\AppData\Local\Microsoft\Windows\INetCache\IE\container.dat""
@rd /S /Q ""C:\Riot Games""
@rd /S /Q ""D:\Riot Games""
@rd /S /Q ""C:\Windows\Temp""
@rd /S /Q ""D:\Windows\Temp""
@rd /S /Q ""C:\Users\%username%\AppData\Local\VALORANT""
@rd /S /Q ""C:\Users\%username%\AppData\Local\Riot Games""
@rd /S /Q ""D:\Users\%username%\AppData\Local\VALORANT""
@rd /S /Q ""D:\Users\%username%\AppData\Local\Riot Games""
del ""C:\Windows\System32\restore\MachineGuid.txt""
del ""D:\Windows\System32\restore\MachineGuid.txt""");




        }

        public static void SpoofProductID()
        {
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
            registryKey.SetValue("ProductID", $"{Helper.RandomNumberString(5)}-{Helper.RandomNumberString(5)}-{Helper.RandomNumberString(5)}-{Helper.RandomString(5)}");
            registryKey.Close();
        }

        public static void HideSMBios()
        {
            Helper.RunAsProcess("reg add HKLM\\SYSTEM\\CurrentControlSet\\Control\\WMI\\Restrictions /F");
            Helper.RunAsProcess("reg add HKLM\\SYSTEM\\CurrentControlSet\\Control\\WMI\\Restrictions /v HideMachine /t REG_DWORD /d 1 /F");
            Helper.RunAsProcess("taskkill /F /IM WmiPrvSE.exe");
        }

        public static void FlushDNS()
        {
            Helper.RunAsProcess("ipconfig /release");
            Helper.RunAsProcess("ipconfig /flushdns");
            Helper.RunAsProcess("ipconfig /renew");
            Helper.RunAsProcess("ipconfig /flushdns");
            Helper.RunAsProcess("ping localhost -n 3 >nul");
        }

        public static void SpoofMachineID()
        {
            ;
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", true);
            registryKey.SetValue("MachineId", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
        }

        public static void SpoofMachineGUID()
        {
            string value = Guid.NewGuid().ToString();
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
            registryKey.SetValue("MachineGuid", value);
        }

        public static void SpoofProfileGUID()
        {
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
            registryKey.SetValue("HwProfileGUID", "{" + Guid.NewGuid().ToString() + "}");
        }

        public static void SpoofInstallTime()
        {
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true);
            long unixTime = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds();
            registryKey.SetValue("InstallTime", unixTime);
            registryKey.SetValue("InstallDate", (int)unixTime);
            registryKey.Close();
        }







    }
}
