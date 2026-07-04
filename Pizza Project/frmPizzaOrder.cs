using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Project
{
    public partial class frmPizzaOrder : Form
    {
        public frmPizzaOrder()
        {
            InitializeComponent();
        }

        private void frmPizzaOrder_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
        //MY OWN FUNCTIONS!!
        float CalculateSizePrice()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMedium.Checked)
                return Convert.ToSingle(rbMedium.Tag);
            else
                return Convert.ToSingle(rbLarge.Tag);
        }

        float CalculateCrustPrice()
        {
            if (rbThick.Checked)
                return Convert.ToSingle(rbThick.Tag);
            else
                return Convert.ToSingle(rbThin.Tag);
        }

        float CalculateToppingsPrice()
        {
            float ToppingsPrice = 0;
            if (chkCheese.Checked)
                ToppingsPrice += Convert.ToSingle(chkCheese.Tag);

            if (chkOnion.Checked)
                ToppingsPrice += Convert.ToSingle(chkOnion.Tag);

            if (chkMushrooms.Checked)
                ToppingsPrice += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOlives.Checked)
                ToppingsPrice += Convert.ToSingle(chkOlives.Tag);

            if (chkTomato.Checked)
                ToppingsPrice += Convert.ToSingle(chkTomato.Tag);

            if (chkGreenPeppers.Checked)
                ToppingsPrice += Convert.ToSingle(chkGreenPeppers.Tag);

            return ToppingsPrice;
        }

        float CalculateTotalPrice()
        {
            return CalculateSizePrice() + CalculateCrustPrice() + CalculateToppingsPrice();
        }

        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
                lblSizeValue.Text = rbSmall.Text;

            if (rbMedium.Checked)
                lblSizeValue.Text = rbMedium.Text;

            if (rbLarge.Checked)
                lblSizeValue.Text = rbLarge.Text;
        }

        void UpdateToppings()
        {

            UpdateTotalPrice();


            string sToppings = "";

            if (chkCheese.Checked)
                sToppings = "Extra Cheese";

            if (chkOnion.Checked)
                sToppings += ", Onion";

            if (chkMushrooms.Checked)
                sToppings += ", Mushrooms";

            if (chkOlives.Checked)
                sToppings += ", Olives";

            if (chkTomato.Checked)
                sToppings += ", Tomatoes";

            if (chkGreenPeppers.Checked)
                sToppings += ", Green Peppers";

            if (sToppings == "")
                sToppings = "No Toppings";

            sToppings = sToppings.TrimStart(',', ' ');

            lblToppingsValue.Text = sToppings;
        }

        void UpdateCrustType()
        {
            UpdateTotalPrice();


            if (rbThick.Checked)
                lblCrustValue.Text = rbThick.Text;
            else
                lblCrustValue.Text = rbThin.Text;
        }

        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
                lblWhereToEatValue.Text = rbEatIn.Text;
            else
                lblWhereToEatValue.Text = rbTakeAway.Text;

        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = CalculateTotalPrice().ToString() + "$";
        }

        void UpdateOrderSummary()
        {
            UpdateSize()      ;
            UpdateToppings()  ;
            UpdateCrustType() ;
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        void ResetForm()
        {
            gbSize.Enabled = true;
            gbCrust.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrder.Enabled = true;

            rbMedium.Checked = true;

            rbThin.Checked = true;

            chkCheese.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomato.Checked = false;
            chkGreenPeppers.Checked = false;

            rbEatIn.Checked = true;

        }
        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void chkCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomato_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEatValue.Text = "Eat In";
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEatValue.Text = "Take Away";

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirm Order?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                MessageBox.Show("Order placed successfully","Success");

                gbSize.Enabled = false;
                gbCrust.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
                btnOrder.Enabled = false;
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
