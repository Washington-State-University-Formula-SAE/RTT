# Prerequisites for this tutorial
1. **[VS Code](https://code.visualstudio.com/Download)**
    - W/ Azure iot extension
    - W/ Python 3.x and pip3  
        Extensions 
        - paho-mqtt  
        - pyserial
        - pygame
1. **[Docker](https://hub.docker.com/)**
1. **[Azure CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)**(optional as you can just do the commands with the portal and VSCode)
    - Make sure to add iot extension `az extension add --name azure-cli-iot-ext`



# IOT Setup Process
1. Install IOT Edge ([Follow for your OS/Container OS](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-iot-edge-linux))([Raspberry pi 4](https://gist.github.com/nihil0/27f7693d066f54c9acc5df8f71f48d52))
1. Connect IOT Edge to azure hub (should be in instructions above)
1. Make Edge device a transparent gateway ([instructions](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-transparent-gateway))
1. Create and link device (there are other ways of doing this...) **For this tutorial name it 'vehicleRPM'**
    1. run `az iot hub device-identity create --hub-name {Hub Name ie wsufsaeHub} --device-id {device name ie vehicleRPM}`
    1. In IOTHub set device to be child of iot hub  
    Or
        1. Create device in portal in the iot edge device (google instructions!)
        1. Or create device with other CLI ([instructions](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-authenticate-downstream-device))
        1. Or create using VSCode (Azure IOT Hub menu)
1. Now lets create our certificates. This will be the important sections that we will use in this setup. (This does not have to be done near your working directory)
    - [Gather Creation Scripts](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-test-certificates#set-up-scripts)
    - [Create our Root Certificate](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-test-certificates#create-root-ca-certificate)
    - [Create our IOT Edge Certificate](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-test-certificates#create-iot-edge-device-ca-certificates)
    - [Create our Device Certificate](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-test-certificates#self-signed-certificates) (We only need to do one, no need for the secondary)
    - [Verify Certificate on Azure](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-create-test-certificates#ca-signed-certificates)
1. Now lets add our certificates to the IOT Edge config
    - open IOTEdge config file (linux: `/etc/iotedge/config.yaml`, windows: `C:\ProgramData\iotedge\config.yaml`)
    - set our 3 lines for certificates with locations ([msdn instructions](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-production-certificates#install-certificates-on-the-device)) **BE SURE THE SPACING IS CORRECT!**
1. Restart IOT Edge and confirm it is running properly (Linux: )

# Program Setup Process
1. Add path_to_root_cert in `MQTT/MQTTDevice.py`
1. Add edge_device_name in `MQTT/MQTTDevice.py`
1. Add SAS token to `MQTT/MQTTDevice.py`
    - Generate device SAS token using VSCode (right click on device name and generate sas token)
    - Paste in `MQTTDevice` for the SAS token
1. Add IOTHubName in `MQTT/MQTTDevice.py`


# Running Car Simulator
1. Run `Car.py` file


    


 