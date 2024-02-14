using System;

namespace School.Logic
{
    public abstract class Person
    {
        // Fields

        // Playing with auto-proerties
        public string? name { get; set; }

        /* btw, C# has multi-line commenting, we start it and finish it, and do not have to mark each line in between
        See? no comment marking, but this is still a comment. Cool, huh?

        auto-properties let us use a field as if it were public, like this...
        myPerson.name = "Russell"; 

        But "under the hood", .NET is REALLY implementing a private variable/object in memory,
        and giving us public properties to modify that value. Like this...

        private string _email;
        public string getEmail()
        {
            return _email;
        }
        public void setEmail( string email)
        {
            this._email = email;
        }

        This is important to remember, because you can still control if a field has get or set methods
        by just leaving those keywords out when you define the auto-prop. Like this...

        public string name { get; }

        This PRIVATE field will have a PUBLIC getter-method, but no access for an external
        class or method to SET a value for it.

        Thanks to Visshal and whomever else helped debug my forgetfullness - you can set a
        default value for a field with an auto-prop as well! Like so...

        public string name { get; } = "Richard";

        This next line closes out the block of multi-line commenting. Without it, the comment continues to the end of the file!
        */ 

        // Person.getEmail();
        // Person.setEmail(email);

        public string? email;
        public string? address1;
        public string? address2;
        public string? city;
        public string? state;
        public int? zip;

        // No need for a constructor! 
        // It's abstract you can't build one, so we don't need to define how to build one!

        // Methods
        public abstract string ToString();
    }
}