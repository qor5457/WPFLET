using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HardWareMatching
{
    public class SerialModel
    {
        private SerialPort SerialPort { get; set; }
        private string SerialID { get; set; }
        private string PortName { get; set; }
        private int DataBits { get; set; }
        private int BaudRate { get; set; }
        private Parity ParityBit { get; set; }
        private StopBits StopBits { get; set; }
    }
}

//    public interface ISerialCommunicator
//    {
//        Task WriteLineAsync(byte[] data);
//        void Close();
//        bool IsOpen();
//    }

//    public class SerialCommunicator : ISerialCommunicator
//    {
//        private readonly SerialPort _serialPort;
//        IDataQueue dataQueue;

//        public SerialCommunicator(string portName, int baudRate)
//        {
//            _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
//            try
//            {
//                _serialPort.Open();
//                dataQueue = new ConcurrentDataQueue(_serialPort);
//                dataQueue.Start();
//                _serialPort.DataReceived += SerialPort_DataReceived;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error opening serial port: " + ex.Message);
//                return;
//            }
//        }

//        public void Close()
//        {
//            _serialPort.Close();
//        }

//        public bool IsOpen()
//        {
//            return _serialPort.IsOpen;
//        }

//        private async void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//            Read();
//        }

//        public async Task WriteLineAsync(byte[] data)
//        {
//            await Task.Run(() => dataQueue.SendData(data));
//        }

//        public string Read()
//        {
//            //return await Task.Run(() => _serialPort.ReadLine());
//            return null;
//        }
//    }

//    public interface IDataQueue
//    {
//        void HandleTxMessage();
//        void HandleRxMessage();
//        void Start();
//        void SendData(byte[] data);
//        bool TryReceiveData(out byte[] data);
//        void Stop();
//    }

//    public class ConcurrentDataQueue : IDataQueue
//    {
//        SerialPort _serialPort;

//        private ConcurrentQueue<byte[]> sendQueue;
//        private ConcurrentQueue<byte[]> receiveQueue;

//        private Thread sendThread;
//        private Thread receiveThread;
//        private ThreadStart sendStart;
//        private ThreadStart receiveStart;

//        private bool running;

//        public ConcurrentDataQueue(SerialPort serialPort)
//        {
//            _serialPort = serialPort;
//            sendQueue = new ConcurrentQueue<byte[]>();
//            receiveQueue = new ConcurrentQueue<byte[]>();


//            sendStart = new ThreadStart(HandleTxMessage);
//            receiveStart = new ThreadStart(HandleRxMessage);
//            sendThread = new Thread(sendStart);
//            receiveThread = new Thread(receiveStart);
//            running = false;
//        }

//        public void Start()
//        {
//            running = true;
//            sendThread.Start();
//            receiveThread.Start();
//        }

//        public void Stop()
//        {
//            running = false;
//        }

//        //ToDo 작업
//        public void HandleTxMessage()
//        {
//            while (running)
//            {
//                if (sendQueue.TryDequeue(out byte[] data))
//                {
//                    _serialPort.Write(data, 0, data.Length);
//                }
//            }
//        }
//        //ToDo: 작업
//        public void HandleRxMessage()
//        {
//            while (running)
//            {
//                // Receive data from serial port
                
//                byte[] data = new byte[] { };
//                _serialPort.Read(data, 0, data.Length);
//                receiveQueue.Enqueue(data);
//            }
//        }

//        public void SendData(byte[] data)
//        {
//            sendQueue.Enqueue(data);
//        }

//        public bool TryReceiveData(out byte[] data)
//        {
//            return receiveQueue.TryDequeue(out data);
//        }
//    }
//}
