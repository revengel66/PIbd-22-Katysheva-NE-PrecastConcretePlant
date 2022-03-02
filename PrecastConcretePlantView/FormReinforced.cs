using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrecastConcretePlantContracts.BindingModels;
using PrecastConcretePlantContracts.BusinessLogicsContracts;
using PrecastConcretePlantContracts.ViewModels;
using Unity;

namespace PrecastConcretePlantView
{
    public partial class FormReinforced : Form
    {
        public int Id { set { id = value; } }
        private readonly IReinforcedLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> ReinforcedComponents;
        public FormReinforced(IReinforcedLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }
        private void FormReinforced_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    ReinforcedViewModel view = _logic.Read(new ReinforcedBindingModel{ Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.ReinforcedName;
                        textBoxPrice.Text = view.Price.ToString();
                        ReinforcedComponents = view.ReinforcedComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ReinforcedComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (ReinforcedComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in ReinforcedComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReinforcedComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ReinforcedComponents.ContainsKey(form.Id))
                {
                    ReinforcedComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    ReinforcedComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormReinforcedComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = ReinforcedComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ReinforcedComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        ReinforcedComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (ReinforcedComponents == null || ReinforcedComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new ReinforcedBindingModel
                {
                    Id = id,
                    ReinforcedName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ReinforcedComponents = ReinforcedComponents
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
