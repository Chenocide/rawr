﻿using System;
using System.Collections.Generic;

namespace Rawr.WarlockOld 
{
    public partial class CalculationOptionsPanelWarlock : CalculationOptionsPanelBase 
    {
        private CalculationOptionsWarlock _options;
        private bool _loading;

        public CalculationOptionsPanelWarlock() 
        {
            InitializeComponent();
        }

        protected override void LoadCalculationOptions() 
        {
            if (Character.CalculationOptions == null) { Character.CalculationOptions = new CalculationOptionsWarlock(); }

            _options = (CalculationOptionsWarlock)Character.CalculationOptions;
            _loading = true;
            
            // Adding this switch to handle target level transition from relative to actual
            switch (_options.TargetLevel)
            {
                case 0:
                case 1:
                case 2:
                case 3: { _options.TargetLevel += 80; break; }
                default: { break; } // Do nothing if it's already transitioned
            }

            cbTargetLevel.Text = _options.TargetLevel.ToString();

            chkPTRMode.Checked = _options.PTR;
            chkPTRMode.Text = "PTR Mode (Patch 3.3 - Build 10956)";

            updFightLength.Value = _options.Duration;
            updAfflictionEffects.Value = _options.AffEffectsNumber;
            updLatency.Value = (int)_options.Latency;
            updReplenishment.Value = (int)_options.Replenishment;
            updJudgementOfWisdom.Value = (int)_options.JoW;

            cbManaAmt.SelectedIndex = _options.ManaPot;

            if (_options.SpellPriority == null)
            {
                _options.SpellPriority = new List<String> { "Shadow Bolt" };
            }
            lsSpellPriority.Items.Clear();
            lsSpellPriority.Items.AddRange(_options.SpellPriority.ToArray());

            //pet options
            //TODO: add pet buffs
            cbPet.SelectedItem = _options.Pet;
            chbUseInfernal.Checked = _options.UseInfernal;

            _loading = false;
        }

        private void cmbManaAmt_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (_loading) return;
            if (_options != null) _options.ManaPot = cbManaAmt.SelectedIndex;
            Character.OnCalculationsInvalidated();
        }
 
        private void cbTargetLevel_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (_loading) return;
            if (_options != null) _options.TargetLevel = Convert.ToInt32(cbTargetLevel.Text);
            Character.OnCalculationsInvalidated();
        }

        private void cbPet_SelectedIndexChanged(object sender, EventArgs e) 
        {
            if (_loading) return;
            if (_options != null) _options.Pet = (String)cbPet.SelectedItem;
            Character.OnCalculationsInvalidated();
        }

        private void chbUseInfernal_CheckedChanged(object sender, EventArgs e) 
        {
            if (_loading) return;
            if (_options != null) _options.UseInfernal = chbUseInfernal.Checked;
            Character.OnCalculationsInvalidated();
        }

        private void textEvents_DoubleClick(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) textEvents.Text = _options.castseq;
        }

        private void btnChangePriority_Click(object sender, EventArgs e)
        {
            SpellPriorityForm f = new SpellPriorityForm(_options.WarlockSpells, lsSpellPriority);
            f.ShowDialog();

            _options.SpellPriority.Clear();
            foreach (string s in lsSpellPriority.Items)
            {
                _options.SpellPriority.Add(s);
            }
            
            Character.OnCalculationsInvalidated();
        }

        private void updFightLength_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) _options.Duration = (int)updFightLength.Value;
            Character.OnCalculationsInvalidated();
        }

        private void updAfflictionEffects_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) _options.AffEffectsNumber = (int)updAfflictionEffects.Value;
            Character.OnCalculationsInvalidated();
        }

        private void updLatency_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) _options.Latency = (int)updLatency.Value;
            Character.OnCalculationsInvalidated();
        }

        private void updReplenishment_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) _options.Replenishment = (float)updReplenishment.Value;
            Character.OnCalculationsInvalidated();
        }

        private void updJudgementOfWisdom_ValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;
            if (_options != null) _options.JoW = (float)updJudgementOfWisdom.Value;
            Character.OnCalculationsInvalidated();
        }
    }
}