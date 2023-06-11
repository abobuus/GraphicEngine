using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;

namespace GraphicEngine
{
    public class Identifier
    {
        readonly string id;
        static string id_last = " ";

        public Identifier()
        {
            id = id_last;
            IdIncrement(id_last.Length - 1);
        }

        public string ID { get { return id; } }

        static void IdIncrement(int index)
        {
            bool flag = false;
            char changed = id_last[index];
            changed = (char)(changed + 1);

            if (changed == 127)
            {
                changed = (char)32;
                flag = true;
            }

            id_last = id_last.Remove(index, 1);
            id_last = id_last.Insert(index, changed.ToString());

            if (flag)
                if (index == 0)
                    id_last = id_last.Insert(0, "!");
                else
                    IdIncrement(index - 1);
        }
    }
}

