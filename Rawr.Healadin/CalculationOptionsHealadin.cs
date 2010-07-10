﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

namespace Rawr.Healadin
{
    public class CalculationOptionsHealadin : ICalculationOptionBase, INotifyPropertyChanged
    {
        public string GetXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CalculationOptionsHealadin));
            StringBuilder xml = new StringBuilder();
            System.IO.StringWriter writer = new System.IO.StringWriter(xml);
            serializer.Serialize(writer, this);
            return xml.ToString();
        }

        public CalculationOptionsHealadin()
        {
            length = 7;
            activity = .85f;
            replenishment = .9f;
            divinePlea = 2f;
            boLUp = 1f;
            boLEff = .2f;
            holyShock = .15f;
            burstScale = .4f;
            gHL_Targets = 1f;
            infusionOfLight = true;
            ioLHolyLight = .9f;
            jotP = true;
            judgement = true;
            loHSelf = false;
            sSUptime = 1f;
            folOnTank = 0.25f;
            hitIrrelevant = true;
            spiritIrrelevant = true;
        }

        private float length;
        public float Length
        {
            get { return length; }
            set { length = value; OnPropertyChanged("Length"); }
        }

        private float activity;
        public float Activity
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged("Activity"); }
        }

        private float replenishment;
        public float Replenishment
        {
            get { return replenishment; }
            set { replenishment = value; OnPropertyChanged("Replenishment"); }
        }

        private float divinePlea;
        public float DivinePlea
        {
            get { return divinePlea; }
            set { divinePlea = value; OnPropertyChanged("DivinePlea"); }
        }

        private float boLUp;
        public float BoLUp
        {
            get { return boLUp; }
            set { boLUp = value; OnPropertyChanged("BoLUp"); }
        }

        private float boLEff;
        public float BoLEff
        {
            get { return boLEff; }
            set { boLEff = value; OnPropertyChanged("BoLEff"); }
        }

        private float holyShock;
        public float HolyShock
        {
            get { return holyShock; }
            set { holyShock = value; OnPropertyChanged("HolyShock"); }
        }

        private float burstScale;
        public float BurstScale
        {
            get { return burstScale; }
            set { burstScale = value; OnPropertyChanged("BurstScale"); }
        }

        private float gHL_Targets;
        public float GHL_Targets
        {
            get { return gHL_Targets; }
            set { gHL_Targets = value; OnPropertyChanged("GHL_Targets"); }
        }

        private bool infusionOfLight;
        public bool InfusionOfLight
        {
            get { return infusionOfLight; }
            set { infusionOfLight = value; OnPropertyChanged("InfusionOfLight"); }
        }

        private float ioLHolyLight;
        public float IoLHolyLight
        {
            get { return ioLHolyLight; }
            set { ioLHolyLight = value; OnPropertyChanged("IoLHolyLight"); }
        }

        private bool jotP;
        public bool JotP
        {
            get { return jotP; }
            set { jotP = value; OnPropertyChanged("JotP"); }
        }

        private bool judgement;
        public bool Judgement
        {
            get { return judgement; }
            set { judgement = value; OnPropertyChanged("Judgement"); }
        }

        private bool loHSelf;
        public bool LoHSelf
        {
            get { return loHSelf; }
            set { loHSelf = value; OnPropertyChanged("LoHSelf"); }
        }

        private float sSUptime;
        public float SSUptime
        {
            get { return sSUptime; }
            set { sSUptime = value; OnPropertyChanged("SSUptime"); }
        }

        private float folOnTank;
        public float FoLOnTank
        {
            get { return folOnTank; }
            set { folOnTank = value; OnPropertyChanged("FoLOnTank"); }
        }

        private bool spiritIrrelevant;
        public bool SpiritIrrelevant
        {
            get { return spiritIrrelevant; }
            set { spiritIrrelevant = value; OnPropertyChanged("SpiritIrrelevant"); }
        }

        private bool hitIrrelevant;
        public bool HitIrrelevant
        {
            get { return hitIrrelevant; }
            set { hitIrrelevant = value; OnPropertyChanged("HitIrrelevant"); }
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
