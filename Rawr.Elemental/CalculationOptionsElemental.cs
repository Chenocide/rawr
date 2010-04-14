﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rawr.Elemental
{
#if !SILVERLIGHT
	[Serializable]
#endif
	public class CalculationOptionsElemental : ICalculationOptionBase
	{
		[System.Xml.Serialization.XmlIgnore]
		public CharacterCalculationsElemental calculatedStats = null;

		public int BSRatio = 75; // goes from 0 to 100

		public int FightDuration = 300; //5 Minutes
		public bool UseThunderstorm = true;

		public int rotationType = 0;

        //latency in s
        public float LatencyGcd = .15f;
        public float LatencyCast = .075f;

        public int NumberOfTargets = 1;

        public bool UseFireNova = true;
        public bool UseChainLightning = true;

		public string GetXml()
		{
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(CalculationOptionsElemental));
			StringBuilder xml = new StringBuilder();
			System.IO.StringWriter writer = new System.IO.StringWriter(xml);
			serializer.Serialize(writer, this);
			return xml.ToString();
		}
	}
}
