using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24._03
{
    class Program
    {
        static void Main(string[] args)
        {
            var room = Client.Build();
            room.Print();
            Console.WriteLine();
            Console.WriteLine($"Общая стоимость: {room.GetCost()} $\n");
        }
    }
    public interface IItem
    {
        int GetCost();
        void Print();
    }
    public class Client
    {
        public static Composite Build()
        {
            var root = new Composite("                                -Офис-");
            var reception = new Composite("1.Приемная");
            reception.Add(new Leaf("  a.Должна быть выполнена в теплых тонах", 100));
            var table = new Composite("  b.Журнальный столик");
            table.Add(new Leaf("    i.10-20 журналов типа «компьютерный мир»", 25));
            reception.Add(table);
            reception.Add(new Leaf("  c.Мягкий диван", 300));
            reception.Add(new Leaf("  d.Стол секретаря", 150));
            var computer = new Composite("    i.Компьютер");
            computer.Add(new Leaf("      1.Важно наличие большого объема жесткого диска", 500));
            computer.Add(new Leaf("    ii.Офисный инструментарий", 300));
            reception.Add(computer);
            reception.Add(new Leaf("  e.Кулер с теплой и холодной водой", 100));
            root.Add(reception);
            
            var aud1 = new Composite("2.Аудитория 1");
            aud1.Add(new Leaf("  a.10 столов",1000));
            aud1.Add(new Leaf("  b.Доска", 340));
            var ttable = new Composite(" c.Стол учителя ");
            ttable.Add(new Leaf("    i.Компьютер", 1800));
            aud1.Add(ttable);
            aud1.Add(new Leaf("  d.Плакаты математиков", 10));
            root.Add(aud1);
            
            var aud2 = new Composite("3.Аудитория 2");
            var table20 = new Composite("  a.20 столов");
            table20.Add(new Leaf("    i.Столы черного цвета",400));
            table20.Add(new Leaf("    ii.Столы выставлены в овал или круг ", 700));
            aud2.Add(table20);
            aud2.Add(new Leaf("  b.Доска", 100));
            aud2.Add(new Leaf("  c. Мягкий диван",500));
            root.Add(aud2);
            
            var pcAud = new Composite("4. Компьютерная аудитория");
            var pctab10 = new Composite("  a. 10 компьютерных столов");
            var pc = new Composite("    i. Компьютер на каждом столе");
            pc.Add(new Leaf("      1. Процессор 2.2ГРц", 3000));
            pc.Add(new Leaf("      2. Винчестер на 80ГБ", 3000));
            pc.Add(new Leaf("      3. Оперативная память 1024МБ", 3000));
            pctab10.Add(pc);
            pcAud.Add(pctab10);
            root.Add(pcAud);
            
            var EssZim = new Composite("5. Столовая");
            EssZim.Add(new Leaf("  a. Кофейный автомат", 250));
            var tisch = new Composite("  b. Стол");
            tisch.Add(new Leaf("    i.4 стула", 400));
            EssZim.Add(tisch);
            EssZim.Add(new Leaf("  c. Холодильник", 500));
            EssZim.Add(new Leaf("  d. Умывальник", 200));
            root.Add(EssZim);
            return root;
        }
    }
    public class Leaf : IItem
    {
        private string Name;
        private int Cost;
        public Leaf(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
        public int GetCost()
        {
            return Cost;
        }
    }

    public class Composite : IItem
    {
        private string Name;
        private int Cost;
        private List<IItem> Items = new List<IItem>();

        public Composite(string name)
        {
            Name = name;
        }

        public void Add(IItem Leaf)
        {
            Items.Add(Leaf);
        }

        public int GetCost()
        {
            int total = 0;
            foreach (var item in Items)
                total += item.GetCost();
            return total;
        }

        public void Print()
        {
            Console.WriteLine(Name);
            foreach (var item in Items)
                item.Print();
        }
    }
  

   
}
