namespace FotoFly
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class JpgMetadata : IImageMetadata
    {
        private XmpRegionInfo regionInfo;
        private GpsPosition gpsPosition;
        private PeopleList authors;
        private TagList tags;
        private Address iptcAddress;

        public JpgMetadata()
        {
        }

        [XmlAttribute]
        public string Aperture
        {
            get;
            set;
        }

        [XmlIgnore]
        public double Brightness
        {
            get;
            set;
        }

        [XmlAttribute]
        public string ExposureBias
        {
            get;
            set;
        }

        [XmlAttribute]
        public string FocalLength
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Copyright
        {
            get;
            set;
        }

        [XmlAttribute]
        public string CameraModel
        {
            get;
            set;
        }

        [XmlAttribute]
        public string CameraManufacturer
        {
            get;
            set;
        }

        [XmlElementAttribute]
        public XmpRegionInfo RegionInfo
        {
            get
            {
                if (this.regionInfo == null)
                {
                    this.regionInfo = new XmpRegionInfo();
                }

                return this.regionInfo;
            }

            set
            {
                this.regionInfo = value;
            }
        }

        [XmlArray]
        public TagList Tags
        {
            get
            {
                if (this.tags == null)
                {
                    this.tags = new TagList();
                }

                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

        [XmlElementAttribute]
        public Address IptcAddress
        {
            get
            {
                if (this.iptcAddress == null)
                {
                    this.iptcAddress = new Address();
                }

                return this.iptcAddress;
            }

            set
            {
                this.iptcAddress = value;
            }
        }

        [XmlElementAttribute]
        public GpsPosition GpsPosition
        {
            get
            {
                if (this.gpsPosition == null)
                {
                    this.gpsPosition = new GpsPosition();
                }

                return this.gpsPosition;
            }

            set
            {
                this.gpsPosition = value;
            }
        }

        [XmlAttribute]
        public DateTime DateTaken
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Iso
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Width
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Height
        {
            get;
            set;
        }

        [XmlAttribute]
        public int Rating
        {
            get;
            set;
        }

        [XmlAttribute]
        public string ShutterSpeed
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Subject
        {
            get;
            set;
        }

        [XmlAttribute]
        public string Title
        {
            get;
            set;
        }

        public PeopleList Authors
        {
            get
            {
                if (this.authors == null)
                {
                    this.authors = new PeopleList();
                }

                return this.authors;
            }

            set
            {
                this.authors = value;
            }
        }

        [XmlAttribute]
        public string Comment
        {
            get;
            set;
        }

        [XmlIgnore]
        public DateTime DateDigitised
        {
            get;
            set;
        }

        [XmlIgnore]
        public PeopleList People
        {
            get
            {
                PeopleList people = new PeopleList();

                foreach (XmpRegion region in this.RegionInfo.Regions)
                {
                    people.Add(region.PersonDisplayName);
                }

                return people;
            }
        }

        [XmlIgnore]
        public PhotoMetadataEnums.Orientations Orientation
        {
            get
            {
                // Work out Orientation
                if (this.Height > this.Width)
                {
                    return PhotoMetadataEnums.Orientations.Portrait;
                }
                else
                {
                    return PhotoMetadataEnums.Orientations.Landscape;
                }
            }
        }
    }
}