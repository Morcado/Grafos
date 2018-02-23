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
            this.EliminaGraf = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NombreAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.PesoAristas = new System.Windows.Forms.ToolStripMenuItem();
            this.Configuracion = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigurarNodAri = new System.Windows.Forms.ToolStripMenuItem();
            this.Intercamb = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Nuev = new System.Windows.Forms.ToolStripButton();
            this.Abri = new System.Windows.Forms.ToolStripButton();
            this.Guard = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.AgregaNod = new System.Windows.Forms.ToolStripButton();
            this.Dirigida = new System.Windows.Forms.ToolStripButton();
            this.NoDirigida = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripSeparator();
            this.MueveNod = new System.Windows.Forms.ToolStripButton();
            this.MueveGraf = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripSeparator();
            this.EliminaArist = new System.Windows.Forms.ToolStripButton();
            this.EliminaNod = new System.Windows.Forms.ToolStripButton();
            this.EliminaGrafo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.MenuArista = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Peso = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.Complemento = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.MenuArista.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
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
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ArchivoToolStripMenuItem
            // 
            this.ArchivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ArchivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nuevo,
            this.Abrir,
            this.Guardar,
            this.toolStripSeparator2,
            this.Salir});
            this.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem";
            this.ArchivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ArchivoToolStripMenuItem.Text = "Archivo";
            // 
            // Nuevo
            // 
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.ShortcutKeyDisplayString = "    Ctrl+N";
            this.Nuevo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.Nuevo.Size = new System.Drawing.Size(168, 22);
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // Abrir
            // 
            this.Abrir.Name = "Abrir";
            this.Abrir.ShortcutKeyDisplayString = "    Ctrl+O";
            this.Abrir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Abrir.Size = new System.Drawing.Size(168, 22);
            this.Abrir.Text = "Abrir ";
            this.Abrir.Click += new System.EventHandler(this.mnuAbrir_Click);
            // 
            // Guardar
            // 
            this.Guardar.Name = "Guardar";
            this.Guardar.ShortcutKeyDisplayString = "    Ctrl+S";
            this.Guardar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Guardar.Size = new System.Drawing.Size(168, 22);
            this.Guardar.Text = "Guardar";
            this.Guardar.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // Salir
            // 
            this.Salir.Name = "Salir";
            this.Salir.ShortcutKeyDisplayString = "    Alt+F4";
            this.Salir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.Salir.Size = new System.Drawing.Size(168, 22);
            this.Salir.Text = "Salir";
            this.Salir.Click += new System.EventHandler(this.mnuSalir_Click);
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
            this.EliminaArista,
            this.EliminaGraf});
            this.herramientasToolStripMenuItem.Name = "herramientasToolStripMenuItem";
            this.herramientasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.herramientasToolStripMenuItem.Text = "Grafo";
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
            // 
            // AristaDirigida
            // 
            this.AristaDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaDirigida.Image")));
            this.AristaDirigida.Name = "AristaDirigida";
            this.AristaDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaDirigida.Tag = "d";
            this.AristaDirigida.Text = "Dirigida";
            this.AristaDirigida.Click += new System.EventHandler(this.mnuAristaDir_Click);
            // 
            // AristaNoDirigida
            // 
            this.AristaNoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("AristaNoDirigida.Image")));
            this.AristaNoDirigida.Name = "AristaNoDirigida";
            this.AristaNoDirigida.Size = new System.Drawing.Size(135, 22);
            this.AristaNoDirigida.Tag = "nd";
            this.AristaNoDirigida.Text = "No Dirigida";
            this.AristaNoDirigida.Click += new System.EventHandler(this.mnuAristaNoDir_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(210, 6);
            // 
            // MueveNodo
            // 
            this.MueveNodo.Name = "MueveNodo";
            this.MueveNodo.Size = new System.Drawing.Size(213, 22);
            this.MueveNodo.Text = "Mueve Nodo";
            this.MueveNodo.Click += new System.EventHandler(this.mnuMueveNodo_Click);
            // 
            // MueveGrafo
            // 
            this.MueveGrafo.Image = ((System.Drawing.Image)(resources.GetObject("MueveGrafo.Image")));
            this.MueveGrafo.Name = "MueveGrafo";
            this.MueveGrafo.Size = new System.Drawing.Size(213, 22);
            this.MueveGrafo.Text = "Mueve Grafo";
            this.MueveGrafo.Click += new System.EventHandler(this.mnuMueveGrafo_Click);
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
            this.EliminaNodo.Click += new System.EventHandler(this.mnuEliminaNodo_Click);
            // 
            // EliminaArista
            // 
            this.EliminaArista.Image = ((System.Drawing.Image)(resources.GetObject("EliminaArista.Image")));
            this.EliminaArista.Name = "EliminaArista";
            this.EliminaArista.Size = new System.Drawing.Size(213, 22);
            this.EliminaArista.Text = "Elimina Arista";
            this.EliminaArista.Click += new System.EventHandler(this.mnuEliminaArista_Click);
            // 
            // EliminaGraf
            // 
            this.EliminaGraf.Name = "EliminaGraf";
            this.EliminaGraf.Size = new System.Drawing.Size(213, 22);
            this.EliminaGraf.Text = "Elimina Grafo";
            this.EliminaGraf.Click += new System.EventHandler(this.mnuBorraGrafo_Click);
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
            this.Intercamb});
            this.Configuracion.Name = "Configuracion";
            this.Configuracion.Size = new System.Drawing.Size(94, 20);
            this.Configuracion.Text = "Configuración";
            // 
            // ConfigurarNodAri
            // 
            this.ConfigurarNodAri.Image = ((System.Drawing.Image)(resources.GetObject("ConfigurarNodAri.Image")));
            this.ConfigurarNodAri.Name = "ConfigurarNodAri";
            this.ConfigurarNodAri.Size = new System.Drawing.Size(201, 22);
            this.ConfigurarNodAri.Text = "Configurar nodo y arista";
            this.ConfigurarNodAri.Click += new System.EventHandler(this.mnuConfigNodAri_Click);
            // 
            // Intercamb
            // 
            this.Intercamb.Image = ((System.Drawing.Image)(resources.GetObject("Intercamb.Image")));
            this.Intercamb.Name = "Intercamb";
            this.Intercamb.Size = new System.Drawing.Size(201, 22);
            this.Intercamb.Text = "Intercambio";
            this.Intercamb.Click += new System.EventHandler(this.mnuIntercamb_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nuev,
            this.Abri,
            this.Guard,
            this.toolStripButton1,
            this.AgregaNod,
            this.Dirigida,
            this.NoDirigida,
            this.toolStripButton4,
            this.MueveNod,
            this.MueveGraf,
            this.toolStripButton5,
            this.EliminaArist,
            this.EliminaNod,
            this.EliminaGrafo,
            this.toolStripButton6,
            this.toolStripButton9,
            this.toolStripButton2,
            this.Complemento});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 39);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "Barra de Herramientas";
            // 
            // Nuev
            // 
            this.Nuev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Nuev.Image = ((System.Drawing.Image)(resources.GetObject("Nuev.Image")));
            this.Nuev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Nuev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Nuev.Name = "Nuev";
            this.Nuev.Size = new System.Drawing.Size(36, 36);
            this.Nuev.Text = "Nuevo";
            this.Nuev.Click += new System.EventHandler(this.mnuNuevo_Click);
            // 
            // Abri
            // 
            this.Abri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Abri.Image = ((System.Drawing.Image)(resources.GetObject("Abri.Image")));
            this.Abri.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Abri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Abri.Name = "Abri";
            this.Abri.Size = new System.Drawing.Size(36, 36);
            this.Abri.Text = "Abrir";
            this.Abri.Click += new System.EventHandler(this.mnuAbrir_Click);
            // 
            // Guard
            // 
            this.Guard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Guard.Image = ((System.Drawing.Image)(resources.GetObject("Guard.Image")));
            this.Guard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Guard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Guard.Name = "Guard";
            this.Guard.Size = new System.Drawing.Size(36, 36);
            this.Guard.Text = "Guardar";
            this.Guard.Click += new System.EventHandler(this.mnuGuardar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 39);
            // 
            // AgregaNod
            // 
            this.AgregaNod.BackColor = System.Drawing.SystemColors.Control;
            this.AgregaNod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AgregaNod.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.AgregaNod.Image = ((System.Drawing.Image)(resources.GetObject("AgregaNod.Image")));
            this.AgregaNod.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AgregaNod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AgregaNod.Name = "AgregaNod";
            this.AgregaNod.Size = new System.Drawing.Size(36, 36);
            this.AgregaNod.Text = "Agrega un Nodo";
            this.AgregaNod.Click += new System.EventHandler(this.mnuAgregaNod_Click);
            // 
            // Dirigida
            // 
            this.Dirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dirigida.Image = ((System.Drawing.Image)(resources.GetObject("Dirigida.Image")));
            this.Dirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Dirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dirigida.Name = "Dirigida";
            this.Dirigida.Size = new System.Drawing.Size(36, 36);
            this.Dirigida.Text = "Arista Dirigida";
            this.Dirigida.Click += new System.EventHandler(this.mnuAristaDir_Click);
            // 
            // NoDirigida
            // 
            this.NoDirigida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NoDirigida.Image = ((System.Drawing.Image)(resources.GetObject("NoDirigida.Image")));
            this.NoDirigida.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.NoDirigida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NoDirigida.Name = "NoDirigida";
            this.NoDirigida.Size = new System.Drawing.Size(36, 36);
            this.NoDirigida.Text = "Arista no Dirigida";
            this.NoDirigida.Click += new System.EventHandler(this.mnuAristaNoDir_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(6, 39);
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
            this.MueveNod.Click += new System.EventHandler(this.mnuMueveNodo_Click);
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
            this.MueveGraf.Click += new System.EventHandler(this.mnuMueveGrafo_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(6, 39);
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
            this.EliminaArist.Click += new System.EventHandler(this.mnuEliminaArista_Click);
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
            this.EliminaNod.Click += new System.EventHandler(this.mnuEliminaNodo_Click);
            // 
            // EliminaGrafo
            // 
            this.EliminaGrafo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EliminaGrafo.Image = ((System.Drawing.Image)(resources.GetObject("EliminaGrafo.Image")));
            this.EliminaGrafo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EliminaGrafo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EliminaGrafo.Name = "EliminaGrafo";
            this.EliminaGrafo.Size = new System.Drawing.Size(36, 36);
            this.EliminaGrafo.Text = "Elimina Grafo";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton9.Text = "Configuración";
            this.toolStripButton9.Click += new System.EventHandler(this.mnuConfigNodAri_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "Intercambio";
            this.toolStripButton2.Click += new System.EventHandler(this.mnuIntercamb_Click);
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
            // Complemento
            // 
            this.Complemento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Complemento.Image = ((System.Drawing.Image)(resources.GetObject("Complemento.Image")));
            this.Complemento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Complemento.Name = "Complemento";
            this.Complemento.Size = new System.Drawing.Size(23, 36);
            this.Complemento.Text = "Complemento";
            this.Complemento.Click += new System.EventHandler(this.mnuComplemento);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 493);
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
        private System.Windows.Forms.ContextMenuStrip MenuArista;
        private System.Windows.Forms.ToolStripMenuItem Peso;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton Dirigida;
        private System.Windows.Forms.ToolStripButton NoDirigida;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigurarNodAri;
        private System.Windows.Forms.ToolStripMenuItem NombreAristas;
        private System.Windows.Forms.ToolStripMenuItem PesoAristas;
        private System.Windows.Forms.ToolStripMenuItem Intercamb;
        private System.Windows.Forms.ToolStripButton Abri;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton Nuev;
        private System.Windows.Forms.ToolStripSeparator toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripButton5;
        private System.Windows.Forms.ToolStripMenuItem EliminaGraf;
        private System.Windows.Forms.ToolStripButton Guard;
        private System.Windows.Forms.ToolStripButton EliminaGrafo;
        private System.Windows.Forms.ToolStripSeparator toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton Complemento;
    }
}

