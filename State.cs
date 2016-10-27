using System;
using System.Collections.Generic;

namespace Лаба_4._2
{
    public class State
    {
        protected enum formOfPoliticalSystem { unitary, federation, confederation }
        protected double area, people;
        protected string formOPS, name;
        List<State> countryDoAgreement;
        Random rand;

        /// <summary>
        /// Access to name of country
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Access to form of political system
        /// </summary>
        public string FormOPS
        {
            get { return formOPS; }
            set
            {
                if (!Enum.IsDefined(typeof(formOfPoliticalSystem), value))
                    throw new ArgumentException("Form is invalid");
                formOPS = value;
            }
        }

        /// <summary>
        /// access to area of country
        /// </summary>
        public double Area
        {
            get { return area; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Area is less zero or invalid");
                area = value;
            }
        }

        /// <summary>
        /// to amount of people, that exist in country
        /// </summary>
        public double People
        {
            get { return people; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("People is invalid or less zero");
                people = value;
            }
        }
        public List<State> CountryDoAgreement
        {
            get { return countryDoAgreement; }
            protected set { countryDoAgreement = value; }
        }

        public State() : this(100, 1000, "Polsha") { }
        /// <summary>
        /// Initial object of class State
        /// </summary>
        /// <param name="people"></param>
        /// <param name="area"></param>
        /// <param name="name"></param>
        public State(double people, double area, string name)
        {
            if (people <= 0)
                throw new ArgumentException("People is invalid or less zero");
            if (area < 0)
                throw new ArgumentException("Area is less zero or invalid");
            this.area = area;
            this.people = people;
            this.name = name;
            countryDoAgreement = new List<State>();
            rand = new Random();
        }
        
        /// <summary>
        /// determinates whether this country have agreement with other country or not
        /// </summary>
        /// <returns></returns>
        public void DoAgreement(List<State> state)
        {
            foreach (State st in state)
                if (rand.Next(2) == 1)
                    countryDoAgreement.Add(st);
        }

        /// <summary>
        /// add some territory to country
        /// </summary>
        /// <param name="areaNew"></param>
        /// <returns></returns>
        public double AddTerritory(double areaNew)
        {
            area += areaNew;
            return area;
        }

        /// <summary>
        /// delete some territory of country
        /// </summary>
        /// <param name="areaDelete"></param>
        /// <returns></returns>
        public double DeleteTerritory(double areaDelete)
        {
            if (areaDelete > area)
                return area = 0;
            return area -= areaDelete;
        }

        /// <summary>
        /// Return name, form of political system and area of country
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Name country: " + name + "\nArea: " + area + "\nPeople:" + people;
        }

        /// <summary>
        /// podatok = 20
        /// </summary>
        /// <returns></returns>
        public virtual double Podatok()
        {
            return 20;
        }

        /// <summary>
        /// override method Equals and compare name o country
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            State state = obj as State;
            if (state == null)
                return false;
            return this.name == state.name;
        }

        /// <summary>
        /// compare name of contry
        /// </summary>
        /// <param name="state1"></param>
        /// <param name="state2"></param>
        /// <returns></returns>
        public static bool operator ==(State state1, State state2)
        {
            if (ReferenceEquals(state1, null) || ReferenceEquals(state2, null))
                return false;
            return state2.Equals(state1);
        }

        /// <summary>
        /// compare name of country
        /// </summary>
        /// <param name="state1"></param>
        /// <param name="state2"></param>
        /// <returns></returns>
        public static bool operator !=(State state1, State state2)
        {
            return !(state2==state1);
        }
    }
}

