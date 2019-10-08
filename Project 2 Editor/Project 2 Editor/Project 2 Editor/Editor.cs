using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace Project_2_Editor
//=========================================================================================================================

    /*Author : Malesela Sithole
     * Date   : 20/10/2016
     * Purpose: Creating a editor window that will function in a similar fashion
                to Microsoft Word. 
     * =====================================================================================================================
     */

{
    public partial class FormEditor : Form
    {
        public FormEditor()
        {
            InitializeComponent();
        }
        //===================================================================================================================
        #region File Buttons Functions/Methods

        //New
        private void New()
        {
              // Creates the MessageBox with certain specifications.
            DialogResult result = MessageBox.Show("Any unsaved data will be lost!",
            "Continue?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            //If yes is selected
            if (result == DialogResult.Yes)
            {
                richTextBox1.Clear();
            }
            //if no is selected
            else if (result == DialogResult.No)
            {
                result = DialogResult.Abort;
            }
            // If Cancel is selected
            else if (result == DialogResult.Cancel)
            {
                result = DialogResult.Abort;
            }
        }

        //Open
        private void Open()
        {
            // opens existing text
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "All text files|*.txt";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                // Displayes a messagebox that notifies the user the text will be lost.
                DialogResult result = MessageBox.Show("Any unsaved data will be lost!!!",
                    "Continue?", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                //Opens an existing document file
                if (result == DialogResult.OK)
                {
                    richTextBox1.Text = File.ReadAllText(OFD.FileName);
                }

                else if (result == DialogResult.Cancel)
                {
                    result = DialogResult.Cancel;
                }
            }
        }

        //Save
        private void Save()
        {
            // Save documents Document data as.
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "All text files|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFD.FileName, richTextBox1.Text);
            }
        }

        //Save As
        private void SaveAs()
        {
            // Save documents Document data as.
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "All text files|*.txt";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
               File.WriteAllText(SFD.FileName, richTextBox1.Text);
            }
        }

        //Exit
        private void Exit()
        {
            Application.Exit();
        }

        #endregion

        //===================================================================================================================
        #region Edit Methods
        //The following lines of code are for the funtions of the menu edit

        private void Undo()
        {
            richTextBox1.Undo();
        }

        private void Redo()
        {
            richTextBox1.Redo();
        }

        private void Cut()
        {
            richTextBox1.Cut();
        }

        private void Copy()
        {
            richTextBox1.Copy();
        }

        private void Paste()
        {
            richTextBox1.Paste();
        }

        private void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        #endregion

        //===================================================================================================================
        #region ToolBar Methods

        private void Bold()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text to Bold!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {
                // Changes selected text to Bold.
                Font new1, old1;
                old1 = richTextBox1.SelectionFont;
                if (old1.Bold)
                {
                    new1 = new Font(old1, old1.Style & ~FontStyle.Bold);
                }
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Bold);
                richTextBox1.SelectionFont = new1;
            }
        }

        private void Italic()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text to change to Italics!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {

                //Changes the font to Italics.
                Font new1, old1;
                old1 = richTextBox1.SelectionFont;
                if (old1.Italic)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Italic);
                else
                    new1 = new Font(old1, old1.Style | FontStyle.Italic);
                richTextBox1.SelectionFont = new1;
            }
        }

        private void Underline()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text to Underline!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {

                //Changes the text to Underline
                Font new1, old1;
                old1 = richTextBox1.SelectionFont;
                if (old1.Underline)
                    new1 = new Font(old1, old1.Style & ~FontStyle.Underline);

                else
                    new1 = new Font(old1, old1.Style | FontStyle.Underline);
                richTextBox1.SelectionFont = new1;
            }
        }

        private void ColourText()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text to Colour!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {

                if (colorDialog1.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(richTextBox1.SelectedText))
                {
                    //Changes the colour of selected text
                    richTextBox1.SelectionColor = colorDialog1.Color;
                }
                else
                {
                    //Changes the colour of all text
                    richTextBox1.ForeColor = colorDialog1.Color;
                }
            }
        }

        private void UpperCase()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text change to UPPERCASE!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {
                //Changes text to Upper case
                richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
            }
        }

        private void LowerCase()
        {
            //Check if rich edit has text
            if (richTextBox1.Text == "")
            {
                DialogResult result = MessageBox.Show("There is no text to change to lowercase!",
            "Continue?", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //If yes is selected
                if (result == DialogResult.OK)
                {
                    result = DialogResult.Abort;
                }
            }
            else
            {
                //Changes text to Upper case
                richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
            }
        } 

        private void SelectFont()
        {
            //creates a new fontDialog with the name fontDialog1
            FontDialog fontDialog1 = new FontDialog();

            //checks text availability or if its selected or not and executes accordingly
            if (fontDialog1.ShowDialog() == DialogResult.OK & !String.IsNullOrEmpty(richTextBox1.SelectedText))
            {

                //Changes the font for selected text only
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
            else
            {
                //Changes the Font for all text. 
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void PageColour()
        {
            //checks if button is clicked and displays the colorDialog.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //Sets the background Colour.
                richTextBox1.BackColor = colorDialog1.Color;
            }
        }

        #endregion

        //===================================================================================================================
        #region Picture Methods
        //Following lines of code are for the images to be stored
        //Into the program in order to be used

        private void Angel()
        {
            Image img = Image.FromFile("../../Resources/Angel.bmp");
            Clipboard.SetImage(img);
            richTextBox1.Paste();
        }

         private void Angry()
          {
              Image img = Image.FromFile("../../Resources/Angry.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Clown()
          {
              Image img = Image.FromFile("../../Resources/Clown.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void CoolDude()
          {
              Image img = Image.FromFile("../../Resources/CoolDude.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Crazy()
          {
              Image img = Image.FromFile("../../Resources/Crazy.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Devil()
          {
              Image img = Image.FromFile("../../Resources/Devil.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Frightened()
          {
              Image img = Image.FromFile("../../Resources/Frightened.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void InLove()
          {
              Image img = Image.FromFile("../../Resources/InLove.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Nerd()
          {
              Image img = Image.FromFile("../../Resources/Nerd.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Ninja()
          {
              Image img = Image.FromFile("../../Resources/Ninja.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Sad()
          {
              Image img = Image.FromFile("../../Resources/Sad.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Shy()
          {
              Image img = Image.FromFile("../../Resources/Shy.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Sick()
          {
              Image img = Image.FromFile("../../Resources/Sick.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Smiley()
          {
              Image img = Image.FromFile("../../Resources/Smiley.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

          private void Wink()
          {
              Image img = Image.FromFile("../../Resources/Wink.bmp");
              Clipboard.SetImage(img);
              richTextBox1.Paste();
          }

        #endregion

        //Calling Function/Methods

        //===================================================================================================================
        #region File Actions
        //File Key Binding Controls
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call New method
            New();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call Open Method
            Open();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call SaveAs Method
            SaveAs();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call Save Method
            Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Call the Exit Method
            Exit();
        }

        #endregion

        //===================================================================================================================
        #region Edit Actions

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        
        #endregion

        //===================================================================================================================
        #region ToolBar Actions

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Call Bold Method
            Bold();
        }

        private void toolStripItalic_Click(object sender, EventArgs e)
        {
            //Call Italic Method
            Italic();
        }

        private void toolStripUnderline_Click(object sender, EventArgs e)
        {
            //Call Underline Method
            Underline();
        }

        private void toolStripColourText_Click(object sender, EventArgs e)
        {
            //Call ColourText Method
            ColourText();
        }

        private void toolStripUpperCase_Click(object sender, EventArgs e)
        {
            //Call UpperCase Method
            UpperCase();
        }

        private void toolStripLowerCase_Click(object sender, EventArgs e)
        {
            //Call LowerCase Method
            LowerCase();
        }

        private void toolStripFont_Click(object sender, EventArgs e)
        {
            //Call SelectFont Method
            SelectFont();

        }

        private void toolStripBackGroundColour_Click(object sender, EventArgs e)
        {
            //Call PageColour Method
            PageColour();
        }

        private void toolStripButton3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Sets the selected text from the combobox to the RichTextBox 
            richTextBox1.Text = richTextBox1.Text + toolStripComboList.Text;
        }

        #endregion

        //===================================================================================================================
        #region Image Actions

        //Following lines of code call the image functions

        private void toolStripAngel_Click(object sender, EventArgs e)
        {
            Angel();
        }

        private void toolStripAngry_Click(object sender, EventArgs e)
        {
            Angry();
        }

        private void toolStripClown_Click(object sender, EventArgs e)
        {
            Clown();
        }

        private void toolStripCoolDude_Click(object sender, EventArgs e)
        {
            CoolDude();
        }

        private void toolStripCrazy_Click(object sender, EventArgs e)
        {
            Crazy();
        }

        private void toolStripDevil_Click(object sender, EventArgs e)
        {
            Devil();
        }

        private void toolStripFrightened_Click(object sender, EventArgs e)
        {
            Frightened();
        }

        private void toolStripInLove_Click(object sender, EventArgs e)
        {
            InLove();
        }

        private void toolStripNerd_Click(object sender, EventArgs e)
        {
            Nerd();
        }

        private void toolStripNinja_Click(object sender, EventArgs e)
        {
            Ninja();
        }

        private void toolStripSad_Click(object sender, EventArgs e)
        {
            Sad();
        }

        private void toolStripShy_Click(object sender, EventArgs e)
        {
            Shy();
        }

        private void toolStripSick_Click(object sender, EventArgs e)
        {
            Sick();
        }

        private void toolStripSmiley_Click(object sender, EventArgs e)
        {
            Smiley();
        }

        private void toolStripWink_Click(object sender, EventArgs e)
        {
            Wink();
        }

        #endregion

        private void FormEditor_Load(object sender, EventArgs e)
        {
            //When form loads words are loaded into the word ComboList
            Stack cl = new Stack();

            cl.Push("Garden");
            cl.Push("Game");
            cl.Push("Fan");
            cl.Push("Family");
            cl.Push("Earth");
            cl.Push("Ears");
            cl.Push("Dress");
            cl.Push("Diamond");
            cl.Push("Chair");
            cl.Push("Cave");
            cl.Push("Bird");
            cl.Push("Bible");
            cl.Push("Album");
            cl.Push("Airport");

            for (int icount = 0; icount < cl.Count; icount++)
            {
                toolStripComboList.Items.Add(cl.Pop());
                toolStripComboList.Items.Add(cl.Pop());
            }
        }

    }
}