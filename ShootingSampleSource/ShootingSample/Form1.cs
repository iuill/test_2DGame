using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ShootingSample
{
	/// <summary>
	/// Form1 �̊T�v�̐����ł��B
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem_File;
		private System.Windows.Forms.MenuItem menuItem_NewStart;
		private System.Windows.Forms.MenuItem menuItem_Exit;
		private System.Windows.Forms.MenuItem menuItem_Split1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timer1;

		public Form1()
		{
			//
			// Windows �t�H�[�� �f�U�C�i �T�|�[�g�ɕK�v�ł��B
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent �Ăяo���̌�ɁA�R���X�g���N�^ �R�[�h��ǉ����Ă��������B
			//
			this.myInitialize();
		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h 
		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem_File = new System.Windows.Forms.MenuItem();
			this.menuItem_NewStart = new System.Windows.Forms.MenuItem();
			this.menuItem_Split1 = new System.Windows.Forms.MenuItem();
			this.menuItem_Exit = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem_File});
			// 
			// menuItem_File
			// 
			this.menuItem_File.Index = 0;
			this.menuItem_File.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItem_NewStart,
																						  this.menuItem_Split1,
																						  this.menuItem_Exit});
			this.menuItem_File.Text = "�t�@�C��(&F)";
			// 
			// menuItem_NewStart
			// 
			this.menuItem_NewStart.Index = 0;
			this.menuItem_NewStart.Text = "�J�n(&N)";
			this.menuItem_NewStart.Click += new System.EventHandler(this.menuItem_NewStart_Click);
			// 
			// menuItem_Split1
			// 
			this.menuItem_Split1.Index = 1;
			this.menuItem_Split1.Text = "-";
			// 
			// menuItem_Exit
			// 
			this.menuItem_Exit.Index = 2;
			this.menuItem_Exit.Text = "�I��(&X)";
			this.menuItem_Exit.Click += new System.EventHandler(this.menuItem_Exit_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 16;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 12);
			this.ClientSize = new System.Drawing.Size(634, 435);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "�V���[�e�B���O�Q�[�����ǂ�";

		}
		#endregion

		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private Bitmap backgroundImage = null;
		private Bitmap ownBodyImage = null;
		private Bitmap enemyBodyImage = null;
		private Bitmap missileImage = null;
		private Core.OwnBody ownBody = null;
		private Core.MissileList missileList = null;
		private Core.EnemyList enemyList = null;

		private void myInitialize()
		{
			// �_�u���o�b�t�@�����O
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			// �摜�ǂݍ���
			this.backgroundImage = new Bitmap(Core.Constants.BackgroundImageFileName);
			this.ownBodyImage = new Bitmap(Core.Constants.OwnBodyImageFileName);
			this.enemyBodyImage = new Bitmap(Core.Constants.EnemyBodyImageFileName);
			this.missileImage = new Bitmap(Core.Constants.MissileImageFileName);

			this.ownBodyImage.MakeTransparent(this.ownBodyImage.GetPixel(0, 0));
			this.enemyBodyImage.MakeTransparent(this.enemyBodyImage.GetPixel(0, 0));

			this.BackgroundImage = this.backgroundImage;

			// �e��G���e�B�e�B�̏�����
			this.ownBody
				= new ShootingSample.Core.OwnBody(
				new Point(this.ClientRectangle.Width/2 - this.ownBodyImage.Width/2, this.ClientRectangle.Height - 40),
				this.ownBodyImage);
			this.missileList = new Core.MissileList();
			this.enemyList = new ShootingSample.Core.EnemyList();

			// �G�@�̏�����
			for(int x=0; x<8; x++)
				for(int y=0; y<10; y++)
				{
					this.enemyList.Add(new Core.EnemyPu
						(new Point(x*this.enemyBodyImage.Width + 50 + x*20, y*this.enemyBodyImage.Height + 50 + y*8),
						this.enemyBodyImage));
				}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint (e);

			if(this.isComplete == false)
			{
				e.Graphics.DrawImage(this.ownBody.EntityImage, this.ownBody.Position);

				for(int i=0; i<this.missileList.Count; i++)
				{
					Core.MissileBody m = this.missileList[i];
					e.Graphics.DrawImage(m.EntityImage, m.Position);
				}
				for(int i=0; i<this.enemyList.Count; i++)
				{
					Core.BaseEnemy be = this.enemyList[i];
					e.Graphics.DrawImage(be.EntityImage, be.Position);
				}
			}
			else
			{
				if(this.BackgroundImage != this.enemyBodyImage)
				{
					//this.BackgroundImage = this.ownBodyImage;
					this.BackgroundImage = null;
					this.BackColor = Color.Plum;
					for(int i=0; i<8; i++)
					{
						e.Graphics.DrawString("����΂�����(*�L�D�M*)", new Font("MS UI Gothic", 40), new SolidBrush(Color.Pink), 20, i*70);
					}
				}
			}
		}

		private void menuItem_NewStart_Click(object sender, System.EventArgs e)
		{
			this.menuItem_NewStart.Enabled = false;
			this.timer1.Stop();
			this.timer1.Start();
		}

		private void menuItem_Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private Core.KeyEstimate.KeyEstimate missileLaunch
			= new ShootingSample.Core.KeyEstimate.KeyEstimate(
			Core.Constants.KeyInterval_MissileLaunch,
			Core.Win32APIs.Constants.VK_SPACE);
		private Core.KeyEstimate.KeyEstimate moveToRight
			= new ShootingSample.Core.KeyEstimate.KeyEstimate(
			Core.Constants.KeyInterval_MoveToRight,
			Core.Win32APIs.Constants.VK_RIGHT);
		private Core.KeyEstimate.KeyEstimate moveToLeft
			= new ShootingSample.Core.KeyEstimate.KeyEstimate(
			Core.Constants.KeyInterval_MoveToLeft,
			Core.Win32APIs.Constants.VK_LEFT);

		private bool isComplete = false;
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(this.enemyList.Count == 0)
			{
				this.timer1.Stop();
				MessageBox.Show("����ȃQ�[���ɂȂɂ�{�C�ɂȂ��Ă�́H( �,_�T�)�޶�ެȰ�");
				MessageBox.Show("�ł��A�N���A���Ă���Ă��肪�Ƃ�m(__)m");
				this.isComplete = true;
				this.Refresh();
				return;
			}

			byte[] boo = new byte[256];
			if(Core.Win32APIs.user32.GetKeyboardState(boo) == true)
			{
				if(this.missileLaunch.isNewKeyPress(boo) == true)
				{
					this.missileList.Add(
						new Core.MissileBody(
							new Point(this.ownBody.Position.X + this.ownBody.EntityImage.Width/2 - this.missileImage.Width/2,
									this.ownBody.Position.Y - this.missileImage.Height),
							this.missileImage));
					System.Diagnostics.Debug.WriteLine("�~�T�C������2");
				}

				if(this.moveToLeft.isNewKeyPress(boo) == true)
				{
					this.ownBody.MoveToLeft();
					System.Diagnostics.Debug.WriteLine("���Ɉړ�");
				}

				if(this.moveToRight.isNewKeyPress(boo) == true)
				{
					this.ownBody.MoveToRight();
					System.Diagnostics.Debug.WriteLine("�E�Ɉړ�");
				}
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("�L�[�̎擾�Ɏ��s�B");
			}
			for(int i=0; i<this.missileList.Count;)
			{
				Core.MissileBody m = this.missileList[i];
				m.Position = m.GetNextPosition();
				if(m.Position.Y < 0)
				{
					m = null;
					this.missileList.RemoveAt(i);
					continue;
				}

				this.CollisionOfMissileAndEnemy(ref m);
				if(m == null)
				{
					this.missileList.RemoveAt(i);
					continue;
				}
				i++;
			}

			this.Refresh();
		}

		/// <summary>
		/// �~�T�C���ƓG�@�̏Փ˔���B
		/// </summary>
		/// <param name="m"></param>
		private void CollisionOfMissileAndEnemy(ref Core.MissileBody m)
		{
			if(m == null)
				return;

			for(int i=0; i<this.enemyList.Count;)
			{
				Core.BaseEnemy enemy = this.enemyList[i];
				if(m.Position.X + m.EntityImage.Width <= enemy.Position.X
					|| enemy.Position.X + enemy.EntityImage.Width <= m.Position.X)
				{
					i++;
					continue;
				}

				if(m.Position.Y + m.EntityImage.Height <= enemy.Position.Y
					|| enemy.Position.Y + enemy.EntityImage.Height <= m.Position.Y)
				{
					i++;
					continue;
				}

				enemy = null;
				m = null;
				this.enemyList.RemoveAt(i);
				break;
			}
		}
	}
}
