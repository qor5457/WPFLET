using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWareMatching
{

    public interface ISerialCommunicator
    {
        Task WriteLineAsync(string message);
        Task<string> ReadLineAsync();
    }

    public class SerialCommunicator : ISerialCommunicator
    {
        private readonly SerialPort _serialPort;
        IDataQueue dataQueue = new ConcurrentDataQueue();

        public SerialCommunicator(string portName, int baudRate)
        {
            _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            _serialPort.Open();
            _serialPort.DataReceived += SerialPort_DataReceived;
        }

        private async void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(await ReadLineAsync());
        }

        public async Task WriteLineAsync(string message)
        {
            //await Task.Run(() => _serialPort.WriteLine(message));
        }

        public async Task<string> ReadLineAsync()
        {
            //return await Task.Run(() => _serialPort.ReadLine());
            return null;
        }
    }

    public interface IDataQueue
    {
        void EnqueueData(string data);
        string DequeueData();
    }

    public class ConcurrentDataQueue : IDataQueue
    {
        private readonly ConcurrentQueue<string> queue;

        public ConcurrentDataQueue()
        {
            queue = new ConcurrentQueue<string>();
        }

        public void EnqueueData(string data)
        {
            queue.Enqueue(data);
        }

        public string DequeueData()
        {
            if (queue.TryDequeue(out string data))
            {
                return data;
            }

            return null;
        }
    }
}
