
using PrivateSpoofer;
using PrivateSpoofer.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;

List<MacChanger> macList = new List<MacChanger>();



Init();



void Init()
{
    Console.ForegroundColor = ConsoleColor.Green;
    string warn = "Please , Run as Administrator !";
    Console.Title = "quespy spoofer v1";
    Console.SetCursorPosition((Console.WindowWidth - warn.Length) / 2, Console.CursorTop);
    Console.WriteLine(warn);

    Console.WriteLine("");
    string required = "!!!BİOS UPDATE REQUİRED!!!";
    Console.SetCursorPosition((Console.WindowWidth - required.Length) / 2, Console.CursorTop);
    Console.WriteLine(required);

    string info = "1 GET SYSTEM INFO";
    string spof = "2 Run Spoofer";
    string secim = "------Choose Number------";
    string start = "------Process Start , Please Waitinig------";


    Console.SetCursorPosition((Console.WindowWidth - info.Length) / 2, Console.CursorTop);
    Console.WriteLine(info);
    Console.SetCursorPosition((Console.WindowWidth - spof.Length) / 2, Console.CursorTop);
    Console.WriteLine(spof);

    Console.SetCursorPosition((Console.WindowWidth - secim.Length) / 2, Console.CursorTop);
    Console.WriteLine(secim);

    string cevap = Console.ReadLine();
    if (cevap =="2")
    {

        Console.SetCursorPosition((Console.WindowWidth - start.Length) / 2, Console.CursorTop);
        Console.WriteLine(start);

        changeVolumeID("C:");
        Console.WriteLine("1.) Process completed , keep waiting ..."); //Spoof Volume ID C:
        Thread.Sleep(1000); //Wait 1 second

        changeVolumeID("D:");
        Console.WriteLine("2.) Process completed , keep waiting ...");//Spoof Volume ID D:
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.ValorantCleanFull();
        Console.WriteLine("3.) Process completed , keep waiting ...");//Clean Valorant Traces
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.CleanTraces(); // Log Kayıtları Klasörü Siliniyor
        Console.WriteLine("4.) Process completed , keep waiting ..."); //Clean Windows Traces
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SpoofProductID(); //Windows ürün id siliniyor
        Console.WriteLine("5.) Process completed , keep waiting ...");//Spoof Product ID
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SpoofProfileGUID(); //Hardware Profile adresi Değiştiriliyor
        Console.WriteLine("6.) Process completed , keep waiting ...");//Spoof ProfileGUID
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SpoofMachineID(); // MachineId Değiştiriliyor
        Console.WriteLine("7.) Process completed , keep waiting ...");//Spoof MachineID
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SpoofMachineGUID(); // MachineGuid Değiştiriliyor
        Console.WriteLine("8.) Process completed , keep waiting ...");// Spoof MachineGUID
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SpoofInstallTime(); // Windows Kurulum Tarihi Değiştiriliyor
        Console.WriteLine("9.) Process completed , keep waiting ...");// Spoof WindowsInstallDate
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.HideSMBios(); // SMBİOS GİZLENİYOR
        Console.WriteLine("10.) Process completed , keep waiting ...");//  Spoof SMBİOS
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.FlushDNS(); //İP DNS SIFIRLAMASI YAPILIYOR
        Console.WriteLine("11.) Process completed , keep waiting ..."); //Spoof DNS
        Thread.Sleep(1000); //Wait 1 second

        Spoofer.SetComputerName(); //Bilgisayar Adı Değiştiriliyor
        Console.WriteLine("12.) Process completed , keep waiting ..."); //Spoof DNS
        Thread.Sleep(1000); //Wait 1 second



        GetMacAdress(); //Mac Adresleri Listesi
        SetRegistryMac(); // Mac Adresleri Güncelleniyor


        Console.WriteLine("Please restart your computer.Have a fun :)");
        Console.WriteLine("Developed By Quespy");

        Console.ReadLine();
    }

    if (cevap == "1")
    {
        Console.BackgroundColor= ConsoleColor.DarkBlue;
        SystemInfo();
    }
   
}


//Mac Adress Get List
void  GetMacAdress(){
    macList.Clear();
    foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces().Where(
                     a => MacChanger.IsValidMac(a.GetPhysicalAddress().GetAddressBytes(), true)
                 ).OrderByDescending(a => a.Speed))
    {
        macList.Add(new MacChanger(adapter));      
    }
}


//MAC ADRESS SET NEW
void SetRegistryMac()
{
    var say = 0;
    foreach (var item in macList)
    {
        MacChanger a = item as MacChanger;

        if (a.SetRegistryMac(MacChanger.GetNewMac()))
        {
            System.Threading.Thread.Sleep(100);
            say++;
        }

    }
    Console.WriteLine($"12.) Process completed , keep waiting ...");

}

void SystemInfo()
{


    //System İnfo

    List<CommandListModel> commandList = new List<CommandListModel>();
    commandList.Add(new CommandListModel() { command = "wmic baseboard get serialnumber", info = "BaseBoard" });
    commandList.Add(new CommandListModel() { command = "wmic bios get serialnumber", info = "Bios" });
    commandList.Add(new CommandListModel() { command = "wmic cpu get serialnumber", info = "Cpu" });
    commandList.Add(new CommandListModel() { command = "wmic diskdrive get serialnumber", info = "DiskDrive (#1) C:" });
    commandList.Add(new CommandListModel() { command = "wmic path win32_physicalmedia get SerialNumber", info = "Diskdrive (#2)" });
    commandList.Add(new CommandListModel() { command = "wmic path win32_diskdrive get SerialNumber", info = "echo Diskdrive (#3)" });
    commandList.Add(new CommandListModel() { command = "wmic baseboard get manufacturer", info = "BaseBoard" });
    commandList.Add(new CommandListModel() { command = "wmic memorychip get serialnumber", info = "RAM" });
    commandList.Add(new CommandListModel() { command = "wmic cpu get processorid", info = "CPU" });
    commandList.Add(new CommandListModel() { command = "wmic PATH Win32_VideoController GET Description,PNPDeviceID", info = "GPU" });
    commandList.Add(new CommandListModel() { command = "getmac", info = "Mac Address " });


    string res = "";
    for (int i = 0; i < 11; i++)
    {
        var proc1 = new ProcessStartInfo();
        var command = commandList[i].command;
        System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = true;
        System.Diagnostics.Process proc = new System.Diagnostics.Process();
        proc.StartInfo = procStartInfo;
        proc.Start();
        res += "\r\n" + commandList[i].info + "=" + proc.StandardOutput.ReadToEnd();

    }
    Console.WriteLine("                             SYSTEM İNFO                              ");
    Console.WriteLine(res);


    Init();
}


 void changeVolumeID(string surucu)
{
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();

        process.StandardInput.WriteLine("start Volumeid.exe");
        process.StandardInput.Flush();


        process.StandardInput.WriteLine("volumeid " + surucu + randomString(4) + "-" + randomString(4));
        process.StandardInput.Flush();


        process.StandardInput.Close();
        process.WaitForExit();
    
}

static string randomString(int length)
{
    Random rnd = new Random();

    const string chars = "ABCDEF0123456789";
    return new string(Enumerable.Repeat(chars, length)
      .Select(s => s[rnd.Next(s.Length)]).ToArray());
}



