using System;
using System.Collections;

namespace Лаба_4._2
{
    class Republic : State
    {
        double timeManage;
        Random rand;
        ArrayList pre_president=new ArrayList(), ex_president=new ArrayList();

        /// <summary>
        /// presidential, parlamentary, presidential_parlamentary
        /// </summary>
        string kindOR, president;
        enum kindORList { presidential, parlamentary, presidential_parlamentary }
        int a;

        /// <summary>
        /// access to kind of republic
        /// </summary>
        public string KindOR
        {
            get { return kindOR; }
            protected set
            {
                if (!(Enum.IsDefined(typeof(kindORList), value)))
                    throw new ArgumentException("Kind of republic is invalid");
                kindOR = value;
            }
        }

        /// <summary>
        /// access to time of president, that now manages
        /// </summary>
        public double TimeManage
        {
            get { return timeManage; }
            protected set
            {
                if (value <= 0)
                    throw new ArgumentException("Time is invalid");
                timeManage = value;
            }
        }
        public Republic() : this("unitary", "presidential","A",100,1000,5) { 
}
        /// <summary>
        /// Initial object of class Republic   
        /// </summary>
        /// <param name="formOPS">unitary, federation, confederation</param>
        /// <param name="kindOR">presidential, parlamentary, presidential_parlamentary</param>
        /// <param name="pre_president"></param>
        /// <param name="name"></param>
        /// <param name="people"></param>
        /// <param name="area"></param>
        public Republic(string formOPS, string kindOR, string name, double people, double area, double timeManage) : base(people, area, name)
        {
            rand = new Random();
            if (!(Enum.IsDefined(typeof(formOfPoliticalSystem), formOPS)))
                throw new ArgumentException("Form is invalid");
            if (!(Enum.IsDefined(typeof(kindORList), kindOR)))
                throw new ArgumentException("Kind of republic is invalid");
            this.kindOR = kindOR;
            this.formOPS = formOPS;
            this.timeManage = timeManage;
            for (int i = 1; i < 10; i++)
                pre_president.Add("President" + i);
            this.president = Convert.ToString(pre_president[rand.Next(pre_president.Count - 1)]);
            pre_president.Remove(president);
            ex_president.Add(president);
        }

        /// <summary>
        /// change current president in case of he manages over true time or he have done criminal
        /// </summary>
        /// <param name="timeManage"></param>
        /// <param name="timeMC"></param>
        /// <param name="pre_president"></param>
        /// <param name="criminal"></param>
        /// <returns></returns>
        public string ChangePresident(bool criminal, double timeMC)
        {
            if (timeMC <= 0)
                throw new ArgumentException("Time is invalid");
            if (timeManage < timeMC || criminal)
            {
                president= Convert.ToString(pre_president[rand.Next(pre_president.Count - 1)]);
                pre_president.Remove(president);
                ex_president.Add(president);
                return president;
            }
            return this.president;
        }
        public void AddPresident(string pres)
        {
            if (pre_president.Contains(pres)||ex_president.Contains(pres))
                throw new ArgumentException("This president already exist or this ex-president");
            pre_president.Add(pres);
        }

        /// <summary>
        /// podatok * 2
        /// </summary>
        /// <returns></returns>
        public override double Podatok()
        {
            return base.Podatok() * 2;
        }

        /// <summary>
        /// + return president
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + "\nPresident: " + president;
        }

    }
}
