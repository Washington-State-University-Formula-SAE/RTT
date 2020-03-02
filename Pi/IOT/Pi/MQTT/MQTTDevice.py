from paho.mqtt import client as mqtt
import time
import ssl

def on_subscribe(client, userdata, mid, granted_qos):
    print('Subscribed for m' + str(mid))

def on_connect(client, userdata, flags, rc):
    print("Connected with result code "+str(rc))
def on_disconnect(client, userdata, rc):
    print ("Device disconnected with result code: " + str(rc))

def on_message(client, userdata, message):
    print("Received message '" + str(message.payload) + "' on topic '" + message.topic + "' with QoS " + str(message.qos))
def on_publish(client, userdata, mid):
    print ("Device sent message")

def on_log(client, userdata, level, buf):
    print("log: ",buf)

class MQTTDevice:
    path_to_root_cert = '' # e.g. './azure-iot-test-only.root.ca.cert.pem'
    edge_device_name = "" #e.g. raspberrypi.local
    sas_token = ""
    iot_hub_name = "" #e.g. adamtestiot12
    def __init__(self, device_id):
        self.device_id = device_id

        self.client = mqtt.Client(client_id=self.device_id, protocol=mqtt.MQTTv311)
        self.client.on_connect = on_connect
        self.client.on_disconnect = on_disconnect
        self.client.on_publish = on_publish

        self.client.username_pw_set(username=self.iot_hub_name+".azure-devices.net/" + self.device_id + "/api-version=2016-11-14", password=self.sas_token)

        self.client.tls_set(ca_certs=self.path_to_root_cert, certfile=None, keyfile=None, cert_reqs=ssl.CERT_REQUIRED, tls_version=ssl.PROTOCOL_TLSv1, ciphers=None)
        self.client.tls_insecure_set(False)
        self.client.loop_start()
        self.client.connect(self.edge_device_name, port=8883)

    def _SendMessage(self, payload):
        self.client.publish("devices/{device_id}/messages/events/".format(device_id=self.device_id), payload=payload, qos=1)
    def _LoopForever(self):
        self.client.loop_forever()
