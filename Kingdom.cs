using System;
namespace Лаба_4._2
{
    public class Kingdom : Monarchy
    {
        protected string title;
        /// <summary>
        /// access to king
        /// </summary>
        public string Title
        {
            get { return title; }
            protected set { title = value; }
        }
        public Kingdom() : this(20, 200, "confederation", "absolute",  "K","king") { }

        /// <summary>
        /// Initial object of class Kingdom
        /// </summary>
        /// <param name="people"></param>
        /// <param name="area"></param>
        /// <param name="formOPS">unitary, federation, confederation</param>
        /// <param name="kindOM">absolute, theocratic, elective, dual, parlamentary</param>
        /// <param name="monarch"></param>
        /// <param name="name"></param>
        public Kingdom(double people, double area, string formOPS, string kindOM,  string name, string title) : base(people, area, formOPS, kindOM,  name)
        {
            this.title = title;
        }

        /// <summary>
        /// podatok *3 +1
        /// </summary>
        /// <returns></returns>
        public override double Podatok()
        {
            return base.Podatok() * 3 + 1;
        }
        public override string ToString()
        {
            return "It is Kingdom))))))))))))\n" + base.ToString();
        }
    }
}


