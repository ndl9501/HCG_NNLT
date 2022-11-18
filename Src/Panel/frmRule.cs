﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Controller;

namespace HCG_NNLT.Src.Panel
{
    public partial class frmRule : Form
    {
        RuleController ruleController = new RuleController();
        public frmRule()
        {
            InitializeComponent();
        }

        private void getData()
        {
            try
            {
                DataSet rs = ruleController.getAll("rule");
                dgv.DataSource = rs.Tables["rule"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void clearText(Boolean check)
        {
            txtMaNL.Text = "";
            txtTenNL.Text = "";
            txtNCC.Text = "";

            btnAdd.Enabled = check;
            btnEdit.Enabled = !check;
            btnDel.Enabled = !check;
        }

        private void frmRule_Load(object sender, EventArgs e)
        {
            getData();
            clearText(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string TenNL = txtTimKiem.Text.Trim();
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@TenNL", TenNL));
                DataSet rs = ruleController.search("warehouse", data);
                dgv.DataSource = rs.Tables["warehouse"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                String TenNL = txtTenNL.Text.Trim();
                String NCC = txtNCC.Text.Trim();
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@TenNL", TenNL));
                data.Add(new SqlParameter("@NCC", NCC));
                data.Add(new SqlParameter("@SoLuongTon", SoLuongTon));
                int rs = ruleController.insertData(data);
                if (rs <= 0)
                {
                    MessageBox.Show("Không Thành Công !");
                }
                else
                {
                    getData();
                    clearText(true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERR : " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                String MaNL = txtMaNL.Text.Trim();
                String TenNL = txtTenNL.Text.Trim();
                String NCC = txtNCC.Text.Trim();
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@MaNL", MaNL));
                data.Add(new SqlParameter("@TenNL", TenNL));
                data.Add(new SqlParameter("@NCC", NCC));
                data.Add(new SqlParameter("@SoLuongTon", SoLuongTon));
                int rs = ruleController.updateData(data);
                if (rs <= 0)
                {
                    MessageBox.Show("Không Thành Công !");
                }
                else
                {
                    getData();
                    clearText(true);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERR : " + ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                String MaNL = txtMaNL.Text.Trim();
                List<SqlParameter> data = new List<SqlParameter>();
                data.Add(new SqlParameter("@MaNL", MaNL));

                int rs = ruleController.deleteData(data);
                if (rs <= 0)
                {
                    MessageBox.Show("Không Thành Công !");
                }
                else
                {
                    getData();
                    clearText(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERR : " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getData();
            clearText(true);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0)
            {
                clearText(false);
                txtMaNL.Text = dgv.Rows[idx].Cells["MaNL"].Value.ToString();
                txtTenNL.Text = dgv.Rows[idx].Cells["TenNL"].Value.ToString();
                txtNCC.Text = dgv.Rows[idx].Cells["NCC"].Value.ToString();
                //numSoLuongTon.Value = Convert.ToInt32(dgvWarehouse.Rows[idx].Cells["SoLuongTon"].Value.ToString());

            }
        }
    }
}
