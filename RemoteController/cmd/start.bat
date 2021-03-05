@echo off
set ip_address_string="IPv4 Address"
rem Uncomment the following line when using older versions of Windows without IPv6 support (by removing "rem")
rem set ip_address_string="IP Address"
echo Network Connection Test
for /f "usebackq tokens=2 delims=:" %%f in (`ipconfig ^| findstr /c:%ip_address_string%`) do set ip_address_string=%%f

set path_to_exe="C:\Users\Dalib\source\repos\RemoteController\RemoteController\bin\Debug\RemoteController.exe"

%path_to_exe% %ip_address_string%:8181