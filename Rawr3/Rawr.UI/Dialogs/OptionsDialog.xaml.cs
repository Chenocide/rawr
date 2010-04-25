﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using Rawr.Properties;

namespace Rawr.UI
{
    public partial class OptionsDialog : ChildWindow
    {
        public OptionsDialog()
        {
            InitializeComponent();

            CK_MultiThreading.IsChecked = GeneralSettings.Default.UseMultithreading;
            CK_BuffSource.IsChecked = GeneralSettings.Default.DisplayBuffSource;
            CK_GemNames.IsChecked = GeneralSettings.Default.DisplayGemNames;
            //CK_DisplayExtraItemInfo.IsChecked = GeneralSettings.Default.DisplayExtraItemInfo;
            CK_HideEnchantsBasedOnProfs.IsChecked = GeneralSettings.Default.HideProfEnchants;
            WarningsCheck.IsChecked = OptimizerSettings.Default.WarningsEnabled;
            TemplateGemsCheck.IsChecked = OptimizerSettings.Default.TemplateGemsEnabled;
            switch (OptimizerSettings.Default.OptimizationMethod)
            {
                case OptimizationMethod.GeneticAlgorithm:
                    OptimizationMethodCombo.SelectedIndex = 0;
                    break;
                case OptimizationMethod.SimulatedAnnealing:
                    OptimizationMethodCombo.SelectedIndex = 1;
                    break;
            }
            switch (OptimizerSettings.Default.GreedyOptimizationMethod)
            {
                case GreedyOptimizationMethod.AllCombinations:
                    GreedyMethodCombo.SelectedIndex = 0;
                    break;
                case GreedyOptimizationMethod.SingleChanges:
                    GreedyMethodCombo.SelectedIndex = 1;
                    break;
                case GreedyOptimizationMethod.GreedyBest:
                    GreedyMethodCombo.SelectedIndex = 2;
                    break;
            }

            ProcEffectModeCombo.SelectedIndex = GeneralSettings.Default.ProcEffectMode;
            EffectCombinationsCalculationMode.SelectedIndex = GeneralSettings.Default.CombinationEffectMode;

            CB_ItemNameWidthSetting.SelectedIndex = GeneralSettings.Default.ItemNameWidthSetting;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            OptimizerSettings.Default.TemplateGemsEnabled = TemplateGemsCheck.IsChecked.GetValueOrDefault();
            OptimizerSettings.Default.WarningsEnabled = WarningsCheck.IsChecked.GetValueOrDefault();
            GeneralSettings.Default.UseMultithreading = CK_MultiThreading.IsChecked.GetValueOrDefault();
            GeneralSettings.Default.DisplayBuffSource = CK_BuffSource.IsChecked.GetValueOrDefault();
            GeneralSettings.Default.DisplayGemNames   = CK_GemNames.IsChecked.GetValueOrDefault();
            //GeneralSettings.Default.DisplayExtraItemInfo = CK_DisplayExtraItemInfo.IsChecked.GetValueOrDefault();
            GeneralSettings.Default.HideProfEnchants  = CK_HideEnchantsBasedOnProfs.IsChecked.GetValueOrDefault();
            GeneralSettings.Default.ItemNameWidthSetting = CB_ItemNameWidthSetting.SelectedIndex;
            switch (OptimizationMethodCombo.SelectedIndex)
            {
                case 0:
                    OptimizerSettings.Default.OptimizationMethod = OptimizationMethod.GeneticAlgorithm;
                    break;
                case 1:
                    OptimizerSettings.Default.OptimizationMethod = OptimizationMethod.SimulatedAnnealing;
                    break;
            }
            switch (GreedyMethodCombo.SelectedIndex)
            {
                case 0:
                    OptimizerSettings.Default.GreedyOptimizationMethod = GreedyOptimizationMethod.AllCombinations;
                    break;
                case 1:
                    OptimizerSettings.Default.GreedyOptimizationMethod = GreedyOptimizationMethod.SingleChanges;
                    break;
                case 2:
                    OptimizerSettings.Default.GreedyOptimizationMethod = GreedyOptimizationMethod.GreedyBest;
                    break;
            }
            GeneralSettings.Default.ProcEffectMode = ProcEffectModeCombo.SelectedIndex;
            GeneralSettings.Default.CombinationEffectMode = EffectCombinationsCalculationMode.SelectedIndex;
            OnDisplayBuffChanged();
            OnHideProfessionsChanged();
            SpecialEffect.UpdateCalculationMode();
            MainPage.Instance.Character.OnCalculationsInvalidated();
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public static event EventHandler DisplayBuffChanged;
        protected static void OnDisplayBuffChanged()
        {
            if (DisplayBuffChanged != null)
                DisplayBuffChanged(null, EventArgs.Empty);
        }

        public static event EventHandler HideProfessionsChanged;
        protected static void OnHideProfessionsChanged()
        {
            if (HideProfessionsChanged != null)
                HideProfessionsChanged(null, EventArgs.Empty);
        }
    }
}

