﻿// <copyright file="PeopleList.cs" company="Taasss">Copyright (c) 2009 All Right Reserved</copyright>
// <author>Ben Vincent</author>
// <date>2009-11-04</date>
// <summary>PeopleList</summary>
namespace Fotofly
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRootAttribute("People", Namespace = "http://www.tassography.com/fotofly")]
    public class PeopleList : List<string>, ICloneable
    {
        public PeopleList()
        {
        }

        public PeopleList(ReadOnlyCollection<string> readOnlyCollection)
        {
            foreach (string text in readOnlyCollection)
            {
                base.Add(text);
            }
        }

        // Implement Compare
        public new void Add(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                base.Add(value);
            }
        }

        public override bool Equals(object unknownObject)
        {
            if (unknownObject is PeopleList)
            {
                PeopleList compareList = unknownObject as PeopleList;

                if (compareList.Count == this.Count)
                {
                    foreach (string text in compareList)
                    {
                        if (!this.Contains(text))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            return false;
        }

        public object Clone()
        {
            PeopleList clone = new PeopleList();

            foreach (string value in this)
            {
                clone.Add(value);
            }

            return clone;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
