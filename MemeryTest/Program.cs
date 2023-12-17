using System.Net;
using System.Runtime.InteropServices;

namespace MemeryTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test2();
            Console.WriteLine("测试成功!");
            Console.ReadLine();
        }
public static void Test0()
{
    Double[] values = GetData();
    // Compute mean.
    Console.WriteLine("Sample mean: {0}, N = {1}",
                        GetMean(values), values.Length);

    static Double[] GetData()
    {
        var d = 0x7FFFFFC7;
        Random rnd = new Random();
        List<Double> values = new List<Double>();
        for (int ctr = 1; ctr <= int.MaxValue; ctr++)
        {
            values.Add(rnd.NextDouble());
            if (ctr % 10000000 == 0)
            {
                var memSize = ((long)values.Count * 8) / 1024 / 1024 / 1024;
                Console.WriteLine($"Retrieved {ctr} items limit:{d} out:{ctr >= d} {(long)values.Count / 1024 / 1024 / 1024}GB个 of data .{memSize} GB");
            }
        }
        return values.ToArray();
    }

    static Double GetMean(Double[] values)
    {
        Double sum = 0;
        foreach (var value in values)
            sum += value;

        return sum / values.Length;
    }
}
        public static void Test1()
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                ptr = Marshal.AllocHGlobal(int.MaxValue);//默认最大2G申请，单个方法
                Console.WriteLine($"申请成功:{ptr}");
                Marshal.WriteByte(ptr, 66);
                byte buffer0 = Marshal.ReadByte(ptr);             //读取第一个byte中的数据
                Console.WriteLine($"第一字节读取到的数据:{buffer0} {(int)buffer0}");
                Marshal.WriteByte(ptr, int.MaxValue - 1, 77);
                byte buffer3 = Marshal.ReadByte(ptr, int.MaxValue - 1); //读取最后一个byte中的数据
                Console.WriteLine($"最后一字节读取到的数据:{buffer3} {(int)buffer3}");

                Console.ReadLine();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
public static void Test2()
{
    var list = new List<IntPtr>();
    try
    {
        for (int i = 0; i < 8; i++)
        {
            var ptr = Marshal.AllocHGlobal(int.MaxValue);//默认最大2G申请，单个方法
            list.Add(ptr);
            for (int j = 0; j < int.MaxValue; j++)
            {
                Marshal.WriteByte(ptr, j, (byte)(66 + i));
            }
            Console.WriteLine($"写入成功{i}");
        }
        Console.WriteLine("申请完成");
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        foreach (var item in list)
        {
            Marshal.FreeHGlobal(item);
        }
    }
}
    }
}
