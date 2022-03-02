using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrecastConcretePlantBusinessLogic.BusinessLogics;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using Unity;

namespace PrecastConcretePlantView
{
    public partial class FormReinforceds : Form
    {
		[Dependency]
		public new IUnityContainer Container { get; set; }
		private readonly ReinforcedLogic _logic;
		public FormReinforceds(ReinforcedLogic logic)
		{
			InitializeComponent();
			_logic = logic;
		}
		private void FormReinforceds_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				var list = _logic.Read(null);
				if (list != null)
				{
					dataGridView.DataSource = list;
					dataGridView.Columns[0].Visible = false;
					dataGridView.Columns[3].Visible = false;
					dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			FormReinforced form = Container.Resolve<FormReinforced>();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadData();
			}
		}

		private void buttonUpd_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				var form = Container.Resolve<FormReinforced>();
				form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadData();
				}
			}
		}
		private void buttonDel_Click(object sender, EventArgs e)
		{
			if (dataGridView.SelectedRows.Count == 1)
			{
				if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
					try
					{
						_logic.Delete(new ReinforcedBindingModel { Id = id });
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					LoadData();
				}
			}
		}
		private void buttonRef_Click(object sender, EventArgs e)
		{
			LoadData();
		}
	}
}

