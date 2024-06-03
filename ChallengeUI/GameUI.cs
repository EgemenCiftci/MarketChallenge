using CsMarketChallenge;

namespace ChallengeUI
{
    public class GameUI : Control, IRender
    {
        private readonly Image background = Image.FromFile("Assets/background.jpg");
        private readonly Image discount = Image.FromFile("Assets/discount.png");
        private readonly Image money = Image.FromFile("Assets/money.png");
        private readonly Brush color = new SolidBrush(Color.FromArgb(72, 75, 77));
        private readonly StringFormat format = new() { Alignment = StringAlignment.Center };

        private Avatar? player1;
        private Avatar? player2;
        private GameLoop? game;

        public GameUI()
        {
            DoubleBuffered = true;
            Location = new Point(DefaultMargin.Left, DefaultMargin.Top);
            MinimumSize = new Size(background.Width, background.Height);
            Font = new Font(Font.FontFamily, 20, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        public void Render(GameLoop game)
        {
            player1 ??= new Avatar(game.player1);
            player2 ??= new Avatar(game.player2);
            this.game = game;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(background, 0, 0);

            if (game != null)
            {
                int centerX = background.Width / 2;
                int offset = background.Height;
                int index = game.turn - 1;

                while (offset >= 0 && index >= 0)
                {
                    bool d1 = game.decisions1[index];
                    bool d2 = game.decisions2[index];

                    e.Graphics.DrawImage(d1 ? discount : money, centerX - 112, offset - 112, 128, 128);
                    e.Graphics.DrawImage(d2 ? discount : money, centerX - 16, offset - 112, 128, 128);

                    offset -= 96;
                    index--;
                }

                string text1 = $"{game.player1.Author}\n{game.player1.Title}\n{game.score1}$";
                RectangleF rect1 = new(0, 0, centerX - 112, background.Height);
                e.Graphics.DrawString(text1, Font, color, rect1, format);

                string text2 = $"{game.player2.Author}\n{game.player2.Title}\n{game.score2}$";
                RectangleF rect2 = new(centerX + 112, 0, centerX - 112, background.Height);
                e.Graphics.DrawString(text2, Font, color, rect2, format);

                if (player1 != null && player2 != null)
                {
                    Image image1 = player1.GetImage(game.score1 >= game.score2);
                    Image image2 = player2.GetImage(game.score2 >= game.score1);

                    e.Graphics.DrawImage(image1, centerX - image1.Width - 160, background.Height - image1.Height);
                    e.Graphics.DrawImage(image2, centerX + 160, background.Height - image2.Height);
                }
            }
        }
    }
}
