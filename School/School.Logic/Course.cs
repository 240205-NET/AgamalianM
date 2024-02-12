using System;

namespace School.Logic
{
    public  class Course
    {
        // Fields
        public string Id;
        public string name;
        public string department;
        public int creditHours;
        public List<string> Requirements;
        private static int idSeed = 1;

        // Constructors

        /// <summary>
        /// Constructor method for the Course object type.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <param name="creditHours"></param>
        public Course(string name, string department, int creditHours)
        {
            this.name = name;
            this.department = department;
            this.creditHours = creditHours;
            this.Id = department.Substring(0,3) + idSeed.ToString();
            idSeed++;
        }

        // Methods
    }
}