# HyperionScreenCap

Windows screen capture program for the [Hyperion](https://github.com/tvdzwan/hyperion) open-source Ambilight project.

The program uses DirectX 9/11 to capture the screen, resize it and send it to the ProtoBuffer interface of Hyperion.

## Download
[SetupHyperionScreenCap.exe](https://github.com/sabaatworld/HyperionScreenCap/releases/download/v2.0/SetupHyperionScreenCap.exe)

## Dependencies

[DirectX End-User Runtime](https://www.microsoft.com/en-us/download/details.aspx?displaylang=en&id=35)

[Visual C++ Redistributable for Visual Studio 2012](https://www.microsoft.com/en-us/download/details.aspx?id=30679)

[Microsoft Visual C++ 2010 Service Pack 1](https://www.microsoft.com/en-us/download/details.aspx?id=26999)

[Microsoft Visual C++ 2008 Service Pack 1](https://www.microsoft.com/en-us/download/details.aspx?id=26368)


## Configuration

Help for DirectX 11 configuration options is available in the 'Help' tab of the setup window. The defaults for most of the settings should work fine. If you are using a display less than 4K resolution, make sure that you set image scaling factor correctly or else a very small image would be sent to Hyperion.

Comes with a setup form which is accessible via system tray; however you can also manually edit the 'user.config' file under '%APPDATA%\HyperionScreenCap' directory. Here is an example of the config file:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <userSettings>
        <HyperionScreenCap.Properties.Settings>
            <setting name="hyperionServerIP" serializeAs="String">
                <value>0.0.0.0</value>
            </setting>
            <setting name="hyperionServerPort" serializeAs="String">
                <value>19445</value>
            </setting>
            <setting name="hyperionMessagePriority" serializeAs="String">
                <value>10</value>
            </setting>
            <setting name="hyperionMessageDuration" serializeAs="String">
                <value>1500</value>
            </setting>
            <setting name="width" serializeAs="String">
                <value>64</value>
            </setting>
            <setting name="height" serializeAs="String">
                <value>64</value>
            </setting>
            <setting name="captureInterval" serializeAs="String">
                <value>5</value>
            </setting>
            <setting name="notificationLevel" serializeAs="String">
                <value>Info</value>
            </setting>
            <setting name="monitorIndex" serializeAs="String">
                <value>0</value>
            </setting>
            <setting name="captureMethod" serializeAs="String">
                <value>DX11</value>
            </setting>
            <setting name="dx11MaxFps" serializeAs="String">
                <value>60</value>
            </setting>
            <setting name="dx11FrameCaptureTimeout" serializeAs="String">
                <value>1250</value>
            </setting>
            <setting name="dx11ImageScalingFactor" serializeAs="String">
                <value>64</value>
            </setting>
            <setting name="dx11AdapterIndex" serializeAs="String">
                <value>0</value>
            </setting>
            <setting name="dx11MonitorIndex" serializeAs="String">
                <value>0</value>
            </setting>
            <setting name="captureOnStartup" serializeAs="String">
                <value>False</value>
            </setting>
            <setting name="apiPort" serializeAs="String">
                <value>0</value>
            </setting>
            <setting name="apiEnabled" serializeAs="String">
                <value>False</value>
            </setting>
            <setting name="apiExcludedTimesEnabled" serializeAs="String">
                <value>False</value>
            </setting>
            <setting name="apiExcludeTimeStart" serializeAs="String">
                <value>09/22/2017 10:00:00</value>
            </setting>
            <setting name="apiExcludeTimeEnd" serializeAs="String">
                <value>09/22/2017 22:00:00</value>
            </setting>
        </HyperionScreenCap.Properties.Settings>
    </userSettings>
</configuration>
```
