
// This file has been generated by the GUI designer. Do not modify.
namespace MathObjects.UI
{
	public partial class MainWindow2
	{
		private global::Gtk.Table table1;
		
		private global::MathObjects.UI.EnterWidget enterwidget1;
		
		private global::MathObjects.UI.ErrorWidget errorwidget1;
		
		private global::MathObjects.UI.FieldWidget fieldwidget1;
		
		private global::MathObjects.UI.Stack.InputWidget inputwidget1;
		
		private global::MathObjects.UI.Widgets.MathObjetsWidget mathobjetswidget2;
		
		private global::MathObjects.UI.Stack.StackWidget2 stackwidget21;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MathObjects.UI.MainWindow2
			this.Events = ((global::Gdk.EventMask)(1024));
			this.Name = "MathObjects.UI.MainWindow2";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow2");
			this.WindowPosition = ((global::Gtk.WindowPosition)(1));
			// Container child MathObjects.UI.MainWindow2.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table (((uint)(6)), ((uint)(1)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.enterwidget1 = new global::MathObjects.UI.EnterWidget ();
			this.enterwidget1.HeightRequest = 50;
			this.enterwidget1.Events = ((global::Gdk.EventMask)(256));
			this.enterwidget1.Name = "enterwidget1";
			this.table1.Add (this.enterwidget1);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1 [this.enterwidget1]));
			w1.TopAttach = ((uint)(5));
			w1.BottomAttach = ((uint)(6));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.errorwidget1 = new global::MathObjects.UI.ErrorWidget ();
			this.errorwidget1.HeightRequest = 20;
			this.errorwidget1.Events = ((global::Gdk.EventMask)(256));
			this.errorwidget1.Name = "errorwidget1";
			this.table1.Add (this.errorwidget1);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1 [this.errorwidget1]));
			w2.TopAttach = ((uint)(2));
			w2.BottomAttach = ((uint)(3));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.fieldwidget1 = new global::MathObjects.UI.FieldWidget ();
			this.fieldwidget1.Events = ((global::Gdk.EventMask)(256));
			this.fieldwidget1.Name = "fieldwidget1";
			this.table1.Add (this.fieldwidget1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.fieldwidget1]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.inputwidget1 = new global::MathObjects.UI.Stack.InputWidget ();
			this.inputwidget1.Events = ((global::Gdk.EventMask)(256));
			this.inputwidget1.Name = "inputwidget1";
			this.table1.Add (this.inputwidget1);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.inputwidget1]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.mathobjetswidget2 = new global::MathObjects.UI.Widgets.MathObjetsWidget ();
			this.mathobjetswidget2.HeightRequest = 200;
			this.mathobjetswidget2.Events = ((global::Gdk.EventMask)(256));
			this.mathobjetswidget2.Name = "mathobjetswidget2";
			this.table1.Add (this.mathobjetswidget2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.mathobjetswidget2]));
			w5.TopAttach = ((uint)(4));
			w5.BottomAttach = ((uint)(5));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.stackwidget21 = new global::MathObjects.UI.Stack.StackWidget2 ();
			this.stackwidget21.Events = ((global::Gdk.EventMask)(256));
			this.stackwidget21.Name = "stackwidget21";
			this.table1.Add (this.stackwidget21);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1 [this.stackwidget21]));
			w6.TopAttach = ((uint)(3));
			w6.BottomAttach = ((uint)(4));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			this.Add (this.table1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 498;
			this.DefaultHeight = 568;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.KeyPressEvent += new global::Gtk.KeyPressEventHandler (this.OnKeyPressEvent);
		}
	}
}
