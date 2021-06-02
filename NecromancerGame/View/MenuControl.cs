﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace NecromancerGame.View
{
    public sealed class MenuControl : UserControl
    {
        public MenuControl(GameForm gameForm)
        {
            ClientSize = gameForm.Size;
            BackgroundImage = Resources.MenuBackground;
            DoubleBuffered = true;
            BackgroundImageLayout = ImageLayout.Stretch;
            SuspendLayout();
            var menu = InitializeMenu();
            menu.Controls.Add(new Label
            {
                Text = @"Некромант",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("AlundraText", (float) menu.Size.Height / 9),
                Dock = DockStyle.Fill
            }, 0, 0);
            menu.Controls.Add(
                MenuBatton(@"Начать игру", menu.Size.Height / 16, () => gameForm.StartGame(this)), 0, 1);
            menu.Controls.Add(MenuBatton(@"Выход на рабочий стол", menu.Size.Height / 16, Application.Exit), 0, 2);
            Controls.Add(menu);
            ResumeLayout(false);
        }

        private TableLayoutPanel InitializeMenu()
        {
            var tableSize = new Size(ClientSize.Width / 4, ClientSize.Height / 3);
            var tableLocation = new Point(ClientSize.Width / 2 - tableSize.Width / 2,
                ClientSize.Height / 2 - tableSize.Height / 2);
            var table = new TableLayoutPanel
            {
                BackColor = Color.SlateGray,
                Location = tableLocation,
                Size = tableSize,
            };
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            return table;
        }

        public static Button MenuBatton(string text, int textSize, Action action)
        {
            var button = new Button
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("AlundraText", textSize),
                BackColor = Color.DarkGray,
                Dock = DockStyle.Fill
            };
            button.Click += (_, _) => action();
            return button;
        }
    }
}