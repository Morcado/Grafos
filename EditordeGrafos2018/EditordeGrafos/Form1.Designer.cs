namespace EditordeGrafos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.Abrir = new System.Windows.Forms.ToolStripMenuItem();
            this.Guardar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BorraGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.Salir = new System.Windows.Forms.ToolStripMenuItem();
            this.herramientasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregaNodo = new System.Windows.Forms.ToolStripMenuItem();
            this.AgregaRelacion = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaDirigida = new System.Windows.Forms.ToolStripMenuItem();
            this.AristaNoDirigida = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MueveNodo = new System.Windows.Forms.ToolStripMenuItem();
            this.MueveGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminaNodo = new System.Windows.Forms.ToolStripMenuItem();
            this.EliminaArista = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NombreAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.PesoAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuracion = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurarNodAri = new System.Windows.Forms.ToolStripMenuItem();
            this.PropiedadesGrafo = new System.Windows.Forms.ToolStripMenuItem();
            this.Intercamb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AgregaNod = new System.Windows.Forms.ToolStripButton();
            this.Dirigida = new System.Windows.Forms.ToolStripButton();
            this.NoDirigida = new System.Windows.Forms.ToolStripButton();
            this.MueveNod = new System.Windows.Forms.ToolStripButton();
            this.EliminaNod = new System.Windows.Forms.ToolStripButton();
            this.MueveGraf = new System.Windows.Forms.ToolStripButton();
            this.EliminaArist = new System.Windows.Forms.ToolStripButton();
            this.PropiedadesGraf = new System.Windows.Forms.ToolStripButton();
            this.Intercambio = new System.Windows.Forms.ToolStripButton();
            this.MenuArista = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Peso = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MenuArista.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ArchivoToolStripMenuItem,
            this.herramientasToolStripMenuItem,
            this.verToolStripMenuItem,
            this.Configuracion});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // ArchivoToolStripMenuItem
            // 
            this.ArchivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nuevo,
            this.Abrir,
            this.Guardar,
            this.toolStripSeparator2,
            this.BorraGrafo,
            this.toolStripSeparator10,
            this.Salir});
            this.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem";
            this.ArchivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ArchivoToolStripMenuItem.Text = "Archivo";
            this.ArchivoToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Archivo_DropDownItemClicked);
            // 
            // Nuevo
            // 
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.ShortcutKeyDisplayString = "    Ctrl+N";
            this.Nuevo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.Nuevo.Size = new System.Drawing.Size(168, 22);
            this.Nuevo.Text = "Nuevo";
            // 
            // Abrir
            // 
            this.Abrir.Name = "Abrir";
            this.Abrir.ShortcutKeyDisplayString = "    Ctrl+O";
            this.Abrir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Abrir.Size = new System.Drawing.Size(168, 22);
            this.Abrir.Text = "Abrir ";
            // 
            // Guardar
            // 
            this.Guardar.Name = "Guardar";
            this.Guardar.ShortcutKeyDisplayString = "    Ctrl+S";
            this.Guardar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Guardar.Size = new System.Drawing.Size(168, 22);
            this.Guardar.Text = "Guardar";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // BorraGrafo
            // 
            this.BorraGrafo.Name = "BorraGrafo";
            this.BorraGrafo.Size = new System.Drawing.Size(168, 22);
            this.BorraGrafo.Text = "Borra Grafo";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(165, 6);
            // 
            // Salir
            // 
            this.Salir.Name = "Salir";
            this.Salir.ShortcutKeyDisplayString = "    Alt+F4";
            this.Salir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Salir.Size = new System.Drawing.Size(168, 22);
            this.Salir.Text = "Salir";
            // 
            // herramientasToolStripMenuItem
            // 
            this.herramientasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregaNodo,
            this.AgregaRelacion,
            this.toolStripSeparator5,
            this.MueveNodo,
            this.MueveGrafo,
            this.toolStripSeparator7,
            this.EliminaNodo,
            this.EliminaArista});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.herramientasToolStripMenuItem.Text = "Herramientas";
            this.herramientasToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // AgregaNodo
            // 
            this.AgregaNodo.Image = ((System.Drawing.Image)(resources.GetObject("AgregaNodo.Image")));
            this.AgregaNodo.Name = "AgregaNodo";
            this.AgregaNodo.ShortcutKeyDisplayString = "        Ctrl+A";
            this.AgregaNodo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.AgregaNodo.Size = new System.Drawing.Size(213, 22);
            this.AgregaNodo.Text = "Agrega Nodo ";
            // 
            // AgregaRelacion
            // 
            this.AgregaRelacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AristaDirigida,
            this.AristaNoDirigida});
            this.AgregaRelacion.Image = ((System.Drawing.Image)(resources.GetObject("AgregaRelacion.Image")));
            this.AgregaRelacion.Name = "AgregaRelacion";
            this.AgregaRelacion.Size = new System.Drawing.Size(213, 22);
            this.AgregaRelacion.Text = "Agrega Relación";
            this.AgregaRelacion.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.RelacionClicked);
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaDirigida.Text = "Dirigida";
            // 
            // AristaNoDirigida
            // 
            this.AristaNoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaNoDirigida.Image")));
            this.AristaNoDirigida.Name = "AristaNoDirigida";
            this.AristaNoDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaNoDirigida.Text = "No Dirigida";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // MueveNodo
            // 
            this.MueveNodo.Image = global::EditordeGrafos.Properties.Resources.movernodo;
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(213, 22);
            this.MueveNodo.Text = "Mueve Nodo";
            // 
            // MueveGrafo
            // 
            this.MueveGrafo.Image = ((System.Drawing.Image)(resources.GetObject("MueveGrafo.Image")));
            this.MueveGrafo.Name = "MueveGrafo";
            this.MueveGrafo.Size = new System.Drawing.Size(213, 22);
            this.MueveGrafo.Text = "Mueve Grafo";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(210, 6);
            // 
            // EliminaNodo
            // 
            this.EliminaNodo.Image = ((System.Drawing.Image)(resources.GetObject("EliminaNodo.Image")));
            this.EliminaNodo.Name = "EliminaNodo";
            this.EliminaNodo.Size = new System.Drawing.Size(213, 22);
            this.EliminaNodo.Text = "Elimina Nodo";
            // 
            // EliminaArista
            // 
            this.EliminaArista.Image = ((System.Drawing.Image)(resources.GetObject("EliminaArista.Image")));
            this.EliminaArista.Name = "EliminaArista";
            this.EliminaArista.Size = new System.Drawing.Size(213, 22);
            this.EliminaArista.Text = "Elimina Arista";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NombreAristas,
            this.PesoAristas});
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Ver_DropDownItemClicked);
            // 
            // NombreAristas
            // 
            this.NombreAristas.Name = "NombreAristas";
            this.NombreAristas.Size = new System.Drawing.Size(172, 22);
            this.NombreAristas.Text = "Nombre de Aristas";
            // 
            // PesoAristas
            // 
            this.PesoAristas.Name = "PesoAristas";
            this.PesoAristas.Size = new System.Drawing.Size(172, 22);
            this.PesoAristas.Text = "Peso de aristas";
            // 
            // Configuracion
            // 
            this.Configuracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigurarNodAri,
            this.PropiedadesGrafo,
            this.Intercamb});
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.Size = new System.Drawing.Size(94, 20);
            this.Configuracion.Text = "Configuración";
            this.Configuracion.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Configuracion_DropDownItemClicked);
            // 
            // ConfigurarNodAri
            // 
            this.ConfigurarNodAri.Name = "ConfigurarNodAri";
            this.ConfigurarNodAri.Size = new System.Drawing.Size(201, 22);
            this.ConfigurarNodAri.Text = "Configurar nodo y arista";
            // 
            // PropiedadesGrafo
            // 
            this.PropiedadesGrafo.Name = "PropiedadesGrafo";
            this.PropiedadesGrafo.Size = new System.Drawing.Size(201, 22);
            this.PropiedadesGrafo.Text = "Propiedades del grafo";
            // 
            // Intercamb
            // 
            this.Intercamb.Name = "Intercamb";
            this.Intercamb.Size = new System.Drawing.Size(201, 22);
            this.Intercamb.Text = "Intercambio";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgregaNod,
            this.Dirigida,
            this.NoDirigida,
            this.MueveNod,
            this.EliminaNod,
            this.MueveGraf,
            this.EliminaArist,
            this.PropiedadesGraf,
            this.Intercambio,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Barra de Herramientas";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // AgregaNod
            // 
            this.AgregaNod.BackColor = System.Drawing.SystemColors.Control;
            this.AgregaNod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AgregaNod.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.AgregaNod.Image = global::EditordeGrafos.Properties.Resources.add_node1;
            this.AgregaNod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AgregaNod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AgregaNod.Name = "AgregaNod";
            this.AgregaNod.Size = new System.Drawing.Size(36, 36);
            this.AgregaNod.Text = "Agrega un Nodo";
            // 
            // Dirigida
            // 
            this.Dirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dirigida.Image = global::EditordeGrafos.Properties.Resources.dirigido;
            this.Dirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Dirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dirigida.Name = "Dirigida";
            this.Dirigida.Size = new System.Drawing.Size(36, 36);
            this.Dirigida.Text = "Arista Dirigida";
            // 
            // NoDirigida
            // 
            this.NoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NoDirigida.Image = global::EditordeGrafos.Properties.Resources.nodirigido;
            this.NoDirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NoDirigida.Name = "NoDirigida";
            this.NoDirigida.Size = new System.Drawing.Size(36, 36);
            this.NoDirigida.Text = "toolStripButton2";
            // 
            // MueveNod
            // 
            this.MueveNod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveNod.Image = ((System.Drawing.Image)(resources.GetObject("MueveNod.Image")));
            this.MueveNod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MueveNod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveNod.Name = "MueveNod";
            this.MueveNod.Size = new System.Drawing.Size(36, 36);
            this.MueveNod.Text = "Mueve Nodo";
            // 
            // EliminaNod
            // 
            this.EliminaNod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminaNod.Image = ((System.Drawing.Image)(resources.GetObject("EliminaNod.Image")));
            this.EliminaNod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminaNod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminaNod.Name = "EliminaNod";
            this.EliminaNod.Size = new System.Drawing.Size(36, 36);
            this.EliminaNod.Text = "Elimina un Nodo";
            // 
            // MueveGraf
            // 
            this.MueveGraf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MueveGraf.Image = ((System.Drawing.Image)(resources.GetObject("MueveGraf.Image")));
            this.MueveGraf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MueveGraf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MueveGraf.Name = "MueveGraf";
            this.MueveGraf.Size = new System.Drawing.Size(36, 36);
            this.MueveGraf.Text = "Mueve el grafo completo";
            // 
            // EliminaArist
            // 
            this.EliminaArist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminaArist.Image = ((System.Drawing.Image)(resources.GetObject("EliminaArist.Image")));
            this.EliminaArist.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminaArist.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminaArist.Name = "EliminaArist";
            this.EliminaArist.Size = new System.Drawing.Size(36, 36);
            this.EliminaArist.Text = "Elimina una arista";
            // 
            // PropiedadesGraf
            // 
            this.PropiedadesGraf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PropiedadesGraf.Image = ((System.Drawing.Image)(resources.GetObject("PropiedadesGraf.Image")));
            this.PropiedadesGraf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PropiedadesGraf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PropiedadesGraf.Name = "PropiedadesGraf";
            this.PropiedadesGraf.Size = new System.Drawing.Size(36, 36);
            this.PropiedadesGraf.Text = "Propiedades";
            // 
            // Intercambio
            // 
            this.Intercambio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Intercambio.Image = ((System.Drawing.Image)(resources.GetObject("Intercambio.Image")));
            this.Intercambio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Intercambio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Intercambio.Name = "Intercambio";
            this.Intercambio.Size = new System.Drawing.Size(36, 36);
            this.Intercambio.Text = "Intercambio";
            this.Intercambio.ToolTipText = "Intercambia numero por letra o letra por numero";
            // 
            // MenuArista
            // 
            this.MenuArista.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Peso});
            this.MenuArista.Name = "MenuArista";
            this.MenuArista.Size = new System.Drawing.Size(133, 26);
            this.MenuArista.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.MenuArista_Closing);
            // 
            // Peso
            // 
            this.Peso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.Peso.Name = "Peso";
            this.Peso.Size = new System.Drawing.Size(132, 22);
            this.Peso.Text = "Peso Arista";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " Editor de Grafos";
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Resize_form);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.MenuArista.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Abrir;
        private System.Windows.Forms.ToolStripMenuItem Guardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Salir;
        private System.Windows.Forms.ToolStripMenuItem Nuevo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AgregaNod;
        private System.Windows.Forms.ToolStripButton MueveNod;
        private System.Windows.Forms.ToolStripButton EliminaNod;
        private System.Windows.Forms.ToolStripMenuItem herramientasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AgregaNodo;
        private System.Windows.Forms.ToolStripMenuItem AgregaRelacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MueveNodo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem EliminaNodo;
        private System.Windows.Forms.ToolStripMenuItem MueveGrafo;
        private System.Windows.Forms.ToolStripMenuItem AristaDirigida;
        private System.Windows.Forms.ToolStripMenuItem AristaNoDirigida;
        private System.Windows.Forms.ToolStripButton MueveGraf;
        private System.Windows.Forms.ToolStripButton EliminaArist;
        private System.Windows.Forms.ToolStripMenuItem EliminaArista;
        private System.Windows.Forms.ToolStripMenuItem Configuracion;
        private System.Windows.Forms.ToolStripMenuItem BorraGrafo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton PropiedadesGraf;
        private System.Windows.Forms.ContextMenuStrip MenuArista;
        private System.Windows.Forms.ToolStripMenuItem Peso;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton Intercambio;
        private System.Windows.Forms.ToolStripButton Dirigida;
        private System.Windows.Forms.ToolStripButton NoDirigida;
        private System.Windows.Forms.ToolStripMenuItem PropiedadesGrafo;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurarNodAri;
        private System.Windows.Forms.ToolStripMenuItem NombreAristas;
        private System.Windows.Forms.ToolStripMenuItem PesoAristas;
        private System.Windows.Forms.ToolStripMenuItem Intercamb;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

