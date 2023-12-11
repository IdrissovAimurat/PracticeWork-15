using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PracticeWork_15
{
    class MyClass
    {
        private int privateField;
        public MyClass() { }
        public MyClass(int value) { }

        public int PublicProperty { get; set; }
        private int PrivateProperty { get; set; }

        public void OpenMethod() { }
        private void HiddenOperation(int value)
        {
            privateField = value;
            Console.WriteLine($"Выполняется скрытая операция со значением: {value}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Исследование Типа:
            Type type = typeof(MyClass);
            Console.WriteLine($"1. Type Name: {type.Name}");

            Console.WriteLine("   Конструкторы:");
            foreach (var constructor in type.GetConstructors())
                Console.WriteLine($"   - {constructor}");

            Console.WriteLine("   Свойства и Поля:");
            foreach (var member in type.GetMembers())
                Console.WriteLine($"   - {member}");

            Console.WriteLine("   Методы:");
            foreach (var method in type.GetMethods())
                Console.WriteLine($"   - {method}");

            // 2. Создание Экземпляра:
            object instance = Activator.CreateInstance(type);
            Console.WriteLine("\n2. Экземпляр создан успешно");

            // 3. Манипулирование Объектом:
            PropertyInfo property = type.GetProperty("PublicProperty");
            property.SetValue(instance, 36.6);
            Console.WriteLine($"3. PublicProperty Value: {property.GetValue(instance)}");

            MethodInfo methodInfo = type.GetMethod("OpenMethod");
            methodInfo.Invoke(instance, null);
            Console.WriteLine("   OpenMethod успешно выполнен");

            // 4. Расширенное Исследование:
            MethodInfo hiddenMethod = type.GetMethod("HiddenOperation", BindingFlags.NonPublic | BindingFlags.Instance);
            hiddenMethod.Invoke(instance, new object[] { 5 });
        }
    }
}
