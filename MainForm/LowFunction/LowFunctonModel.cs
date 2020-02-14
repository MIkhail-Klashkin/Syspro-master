using System;
using System.IO;
using System.Reflection;
namespace MainForm
{
    class LowFunctionModel:ILowFunctionModel
    {
        private object obj;
        private MethodInfo method;
        
        public LowFunctionModel()
        {
            Assembly asm = Assembly.Load(File.ReadAllBytes("XOR.dll"));
            Type type = asm.GetType("XOR");
            method = type.GetMethod("XOR", BindingFlags.Instance | BindingFlags.Public);
            obj = Activator.CreateInstance(type);
            
        }
        public int XOR(int arg1, int arg2)
        {
            return (Int32)method.Invoke(obj, new object[] { arg1, arg2 });
        }
    }
}
