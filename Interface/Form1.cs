using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface.DataModel;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Migrations;

namespace Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.isIDAtZero = true;
            this.renderUpdateButtons = true;
        }

        private bool isIDAtZero;
        private bool renderUpdateButtons;
        private string SEPARATOR = " / ";
        // gets data from db and puts it into datagrid

        private byte[] openFile()
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Text File";
            theDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            theDialog.InitialDirectory = @"C:\Users\user\Desktop";
            byte[] data = null;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                string path = theDialog.FileName;
                FileInfo fileInfo = new FileInfo(path);

                data = new byte[fileInfo.Length];

                // Load a filestream and put its content into the byte[]
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(data, 0, data.Length);
                }
            }
            return data;
        }


        public void Display()
        {
            using (LibraryContext context = new LibraryContext())
            {
                var bookList = context.Books.Select(x => new {
                    BookId = x.BookId,
                    Title = x.Title,
                    Authors = x.Authors.Select(a => a.Name).ToList()
                }).ToList().Select(x => new {
                    BookId = x.BookId,
                    Title = x.Title,
                    Authors = String.Join(this.SEPARATOR, x.Authors)
                }).ToList();

                var authorList = context.Authors.Select(x => new {
                    AuthorId = x.AuthorId,
                    Name = x.Name,
                    Books = x.Books.Select(b => b.Title).ToList()
                }).ToList().Select(x => new {
                    AuthorId = x.AuthorId,
                    Name = x.Name,
                    Books = String.Join(this.SEPARATOR, x.Books)
                }).ToList();


                book_data_grid.DataSource = bookList;
                author_data_grid.DataSource = authorList;

                this.listBox1.SelectionMode = SelectionMode.MultiSimple;

                this.listBox1.DataSource = context.Authors.Select(x => x.Name).ToList();

            }

            if (this.renderUpdateButtons)
            {
                //dataGridView1.Columns[0].ReadOnly = true; // disable id editing

                var buttonCol = new DataGridViewButtonColumn();
                buttonCol.Name = "ShowImage";
                buttonCol.HeaderText = "Image";
                buttonCol.Text = "Show image";
                buttonCol.UseColumnTextForButtonValue = true;

                book_data_grid.Columns.Insert(3, buttonCol);
                this.renderUpdateButtons = false;
            } else
            {
                //dataGridView1.Columns[1].ReadOnly = true; // disable id editing
                isIDAtZero = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Display();
        }

        private void createNewBookInDb(object sender, EventArgs e)
        {
            var imageData = this.openFile();
            using (LibraryContext context = new LibraryContext())
            {
                Book book = new Book();
                book.Title = this.textBox1.Text;
                book.image = imageData;

                foreach (var item in listBox1.SelectedItems)
                {
                    Author author = context.Authors.Where(a => a.Name == item.ToString()).Single();
                    author.Books.Add(book);
                }
                context.Books.Add(book);
                context.SaveChanges();

            }
            this.Display();
        }

        // Delete button pressed
        private void deleteFromDb(object sender, EventArgs e)
        {
            if (book_data_grid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in book_data_grid.SelectedRows) // foreach datagridview selected rows values  
                {

                    int id;
                    if (this.isIDAtZero)
                    {
                        id = Convert.ToInt32(row.Cells[0].Value);
                    }
                    else
                    {
                        id = Convert.ToInt32(row.Cells[1].Value);
                    }
                    Console.WriteLine("Book with id to delete");
                    Console.WriteLine(id);
                    using (LibraryContext context = new LibraryContext())
                    {
                        Book bookToDelete = context.Books.Where(x => x.BookId == id).Select(x => x).FirstOrDefault();
                        context.Entry(bookToDelete).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    this.Display();
                }
            }
        }





        private void showImage(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                using (Form form = new Form())
                {
                    using (LibraryContext context = new LibraryContext())
                    {
                       
                        Bitmap bmp;
                        try
                        {
                            using (var ms = new MemoryStream(context.Books.ToList()[e.RowIndex].image))
                            {
                                bmp = new Bitmap(ms);
                                form.StartPosition = FormStartPosition.CenterScreen;
                                form.Size = bmp.Size;

                                PictureBox pb = new PictureBox();
                                pb.Dock = DockStyle.Fill;
                                pb.Image = bmp;

                                form.Controls.Add(pb);
                                form.ShowDialog();
                            }
                        }
                        catch { MessageBox.Show(  "Треба було додати картинку!"  );   }

                    }

                }
            }

        }
        //private void updateData(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0)
        //    {
        //        int i = this.isIDAtZero ? 0 : 1;
        //        int id;
        //        if (this.isIDAtZero)
        //        {
        //            id = Convert.ToInt32(this.book_data_grid.Rows[e.RowIndex].Cells[0].Value);
        //        }
        //        else
        //        {
        //            id = Convert.ToInt32(this.book_data_grid.Rows[e.RowIndex].Cells[1].Value);
        //        }
        //        var BookTitle = this.book_data_grid.Rows[e.RowIndex].Cells[i + 1].Value.ToString();
        //        //var AuthorName = this.dataGridView1.Rows[e.RowIndex].Cells[i + 2].Value.ToString();
                
        //        using (LibraryContext context = new LibraryContext())
        //        {
        //            Book bookToUpdate = context.Books.Where(x => x.BookId == id).Select(x => x).FirstOrDefault();
        //            //bookToUpdate.Author = AuthorName;
        //            bookToUpdate.Title = BookTitle;
        //            context.Entry(bookToUpdate).State = System.Data.Entity.EntityState.Modified;
        //            context.SaveChanges();
        //        }

        //    }

        //}

        private void saveAuthorToDB(object sender, EventArgs e)
        {
            var authorName = this.author_name_text_box.Text;
            using (LibraryContext context = new LibraryContext())
            {
                Author author = new Author();
                author.Name = this.author_name_text_box.Text;
             
                context.Authors.Add(author);
                context.SaveChanges();
            }
            author_name_text_box.Text = "";
            this.Display();

        }

        private void delete_author_btn_Click(object sender, EventArgs e)
        {
            if (author_data_grid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in author_data_grid.SelectedRows) // foreach datagridview selected rows values  
                {

                    var id = Convert.ToInt32(row.Cells[0].Value);
                    
                    using (LibraryContext context = new LibraryContext())
                    {
                        Author authorToDelete = context.Authors.Where(x => x.AuthorId == id).Select(x => x).FirstOrDefault();
                        context.Entry(authorToDelete).State = System.Data.Entity.EntityState.Deleted;
                        context.SaveChanges();
                    }
                    this.Display();
                }
            }
        }

        private void open_file_btn_Click(object sender, EventArgs e)
        {
            this.openFile();
        }

        private void editauthor_Click(object sender, EventArgs e)
        {//Editing Author
            if (author_data_grid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in author_data_grid.SelectedRows) // foreach datagridview selected rows values  
                {
                     
                    var id = Convert.ToInt32(row.Cells[0].Value);
                    using (LibraryContext context = new LibraryContext())
                    {
                        Author authorToModify = context.Authors.Where(x => x.AuthorId == id).Select(x => x).FirstOrDefault();
                        context.Entry(authorToModify).State = System.Data.Entity.EntityState.Modified;
                        authorToModify.Name = this.author_name_text_box.Text;
                        context.SaveChanges();
                    }
                    author_name_text_box.Text = "";
                    this.Display();
                }
            }

        }

        private void Edit_Book_Click(object sender, EventArgs e)
        {//Editing Book
            if (book_data_grid.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in book_data_grid.SelectedRows) // foreach datagridview selected rows values  
                {
                     

                    int id;
                    if (this.isIDAtZero)
                    {
                        id = Convert.ToInt32(row.Cells[0].Value);
                    }
                    else
                    {
                        id = Convert.ToInt32(row.Cells[1].Value);
                    }
                     
                    Console.WriteLine("Book with id to EDIT");
                    Console.WriteLine(id);

                    var imageData = this.openFile();
                    using (LibraryContext context = new LibraryContext())
                    {
                        Book bookToEdit = context.Books.Where(x => x.BookId == id).Select(x => x).FirstOrDefault();
                        bookToEdit.Title = this.textBox1.Text;
                        bookToEdit.image = imageData;
                        foreach (var item in listBox1.SelectedItems)
                        {
                            Author author = context.Authors.Where(a => a.Name == item.ToString()).Single();
                            author.Books.Add(bookToEdit);
                        }
                        context.Entry(bookToEdit).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                    this.Display();
                }
            }

        }
    }
}
