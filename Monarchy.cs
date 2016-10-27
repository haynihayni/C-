using System;
using System.Collections;

namespace Лаба_4._2
{
    public class Monarchy : State
    {
        protected enum kindOMList { absolute, theocratic, elective, dual, parlamentary };
        protected string kindOM, monarch;
        Queue dynasty;
        static int count=1;

        /// <summary>
        /// access to monarchy
        /// </summary>
        public string Monarch
        {
            get { return monarch; }
            protected set { monarch = value; }
        }

        /// <summary>
        /// access to kind of monarchy
        /// </summary>
        public string KindOM
        {
            get { return kindOM; }
            set
            {
                if (!Enum.IsDefined(typeof(kindOMList), value))
                    throw new ArgumentException("Kind of republic is invalid");
                kindOM = value;
            }
        }
        public Monarchy (): this(200, 2000, "unitary", "theocratic", "M") { }
        /// <summary>
        /// Initial object of class Monarchy
        /// </summary>
        /// <param name="people"></param>
        /// <param name="area"></param>
        /// <param name="formOPS">unitary, federation, confederation</param>
        /// <param name="kindOM">absolute, theocratic, elective, dual, parlamentary</param>
        /// <param name="monarch"></param>
        /// <param name="name"></param>
        public Monarchy(double people, double area, string formOPS, string kindOM, string name) : base(people, area, name)
        {
            if (!Enum.IsDefined(typeof(formOfPoliticalSystem), formOPS))
                throw new ArgumentException("Form is invalid");
            if (!Enum.IsDefined(typeof(kindOMList), kindOM))
                throw new ArgumentException("Kind of republic is invalid");
            
            this.kindOM = kindOM;
            this.formOPS = formOPS;
            dynasty = new Queue();
            for (int i = 1; i < 10; ++i,++count)
                dynasty.Enqueue("Monarch " + count);
            this.monarch = Convert.ToString(dynasty.Dequeue());
        }

        /// <summary>
        /// change monarchy if previous monarchy have died
        /// </summary>
        /// <param name="lifeOfKing"></param>
        /// <param name="dinasty"></param>
        /// <returns></returns>
        public string ChangeMonarch(bool lifeOfKing)
        {
            if (!lifeOfKing)
            {
                if (dynasty.Peek()==null)
                    throw new ArgumentException("Dinasty have ended");
                return Convert.ToString(dynasty.Dequeue());
            }
            return this.monarch;
        }

        /// <summary>
        /// Add child of monarcy dynasty till dynasty
        /// </summary>
        /// <param name="child"></param>
        public void LifeDinasty(bool child)
        {
            if (child)
            {
                dynasty.Enqueue("Monarchy " + count);
                ++count;
            }
        }

        /// <summary>
        /// podatok *3 
        /// </summary>
        /// <returns></returns>
        public override double Podatok()
        {
            return base.Podatok() * 2.1;
        }
        public override string ToString()
        {
            return base.ToString() + "\nMonarch: " + monarch;
        }
    }
}
