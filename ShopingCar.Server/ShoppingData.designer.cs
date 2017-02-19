﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopingCar.Server
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ShoppingCar")]
	public partial class ShoppingDataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertCliente(Cliente instance);
    partial void UpdateCliente(Cliente instance);
    partial void DeleteCliente(Cliente instance);
    partial void InsertProducto(Producto instance);
    partial void UpdateProducto(Producto instance);
    partial void DeleteProducto(Producto instance);
    partial void InsertDetallePedido(DetallePedido instance);
    partial void UpdateDetallePedido(DetallePedido instance);
    partial void DeleteDetallePedido(DetallePedido instance);
    partial void InsertEstado(Estado instance);
    partial void UpdateEstado(Estado instance);
    partial void DeleteEstado(Estado instance);
    partial void InsertPedido(Pedido instance);
    partial void UpdatePedido(Pedido instance);
    partial void DeletePedido(Pedido instance);
    #endregion
		
		public ShoppingDataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ShoppingCarConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ShoppingDataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShoppingDataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShoppingDataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ShoppingDataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Cliente> Cliente
		{
			get
			{
				return this.GetTable<Cliente>();
			}
		}
		
		public System.Data.Linq.Table<Producto> Producto
		{
			get
			{
				return this.GetTable<Producto>();
			}
		}
		
		public System.Data.Linq.Table<DetallePedido> DetallePedido
		{
			get
			{
				return this.GetTable<DetallePedido>();
			}
		}
		
		public System.Data.Linq.Table<Estado> Estado
		{
			get
			{
				return this.GetTable<Estado>();
			}
		}
		
		public System.Data.Linq.Table<Pedido> Pedido
		{
			get
			{
				return this.GetTable<Pedido>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cliente")]
	public partial class Cliente : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nombres;
		
		private string _Correo;
		
		private string _Clave;
		
		private EntitySet<Pedido> _Pedido;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNombresChanging(string value);
    partial void OnNombresChanged();
    partial void OnCorreoChanging(string value);
    partial void OnCorreoChanged();
    partial void OnClaveChanging(string value);
    partial void OnClaveChanged();
    #endregion
		
		public Cliente()
		{
			this._Pedido = new EntitySet<Pedido>(new Action<Pedido>(this.attach_Pedido), new Action<Pedido>(this.detach_Pedido));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombres", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Nombres
		{
			get
			{
				return this._Nombres;
			}
			set
			{
				if ((this._Nombres != value))
				{
					this.OnNombresChanging(value);
					this.SendPropertyChanging();
					this._Nombres = value;
					this.SendPropertyChanged("Nombres");
					this.OnNombresChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Correo", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Correo
		{
			get
			{
				return this._Correo;
			}
			set
			{
				if ((this._Correo != value))
				{
					this.OnCorreoChanging(value);
					this.SendPropertyChanging();
					this._Correo = value;
					this.SendPropertyChanged("Correo");
					this.OnCorreoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Clave", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Clave
		{
			get
			{
				return this._Clave;
			}
			set
			{
				if ((this._Clave != value))
				{
					this.OnClaveChanging(value);
					this.SendPropertyChanging();
					this._Clave = value;
					this.SendPropertyChanged("Clave");
					this.OnClaveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_Pedido", Storage="_Pedido", ThisKey="Id", OtherKey="ClienteId")]
		public EntitySet<Pedido> Pedido
		{
			get
			{
				return this._Pedido;
			}
			set
			{
				this._Pedido.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = this;
		}
		
		private void detach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Cliente = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Producto")]
	public partial class Producto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nombre;
		
		private string _Precio;
		
		private string _Path;
		
		private EntitySet<DetallePedido> _DetallePedido;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnPrecioChanging(string value);
    partial void OnPrecioChanged();
    partial void OnPathChanging(string value);
    partial void OnPathChanged();
    #endregion
		
		public Producto()
		{
			this._DetallePedido = new EntitySet<DetallePedido>(new Action<DetallePedido>(this.attach_DetallePedido), new Action<DetallePedido>(this.detach_DetallePedido));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Precio", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Precio
		{
			get
			{
				return this._Precio;
			}
			set
			{
				if ((this._Precio != value))
				{
					this.OnPrecioChanging(value);
					this.SendPropertyChanging();
					this._Precio = value;
					this.SendPropertyChanged("Precio");
					this.OnPrecioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Path", DbType="VarChar(MAX)")]
		public string Path
		{
			get
			{
				return this._Path;
			}
			set
			{
				if ((this._Path != value))
				{
					this.OnPathChanging(value);
					this.SendPropertyChanging();
					this._Path = value;
					this.SendPropertyChanged("Path");
					this.OnPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Producto_DetallePedido", Storage="_DetallePedido", ThisKey="Id", OtherKey="ProductoId")]
		public EntitySet<DetallePedido> DetallePedido
		{
			get
			{
				return this._DetallePedido;
			}
			set
			{
				this._DetallePedido.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DetallePedido(DetallePedido entity)
		{
			this.SendPropertyChanging();
			entity.Producto = this;
		}
		
		private void detach_DetallePedido(DetallePedido entity)
		{
			this.SendPropertyChanging();
			entity.Producto = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DetallePedido")]
	public partial class DetallePedido : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _PedidoId;
		
		private int _ProductoId;
		
		private int _Cantidad;
		
		private EntityRef<Producto> _Producto;
		
		private EntityRef<Pedido> _Pedido;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPedidoIdChanging(int value);
    partial void OnPedidoIdChanged();
    partial void OnProductoIdChanging(int value);
    partial void OnProductoIdChanged();
    partial void OnCantidadChanging(int value);
    partial void OnCantidadChanged();
    #endregion
		
		public DetallePedido()
		{
			this._Producto = default(EntityRef<Producto>);
			this._Pedido = default(EntityRef<Pedido>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PedidoId", DbType="Int NOT NULL")]
		public int PedidoId
		{
			get
			{
				return this._PedidoId;
			}
			set
			{
				if ((this._PedidoId != value))
				{
					if (this._Pedido.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPedidoIdChanging(value);
					this.SendPropertyChanging();
					this._PedidoId = value;
					this.SendPropertyChanged("PedidoId");
					this.OnPedidoIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductoId", DbType="Int NOT NULL")]
		public int ProductoId
		{
			get
			{
				return this._ProductoId;
			}
			set
			{
				if ((this._ProductoId != value))
				{
					if (this._Producto.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProductoIdChanging(value);
					this.SendPropertyChanging();
					this._ProductoId = value;
					this.SendPropertyChanged("ProductoId");
					this.OnProductoIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cantidad", DbType="Int NOT NULL")]
		public int Cantidad
		{
			get
			{
				return this._Cantidad;
			}
			set
			{
				if ((this._Cantidad != value))
				{
					this.OnCantidadChanging(value);
					this.SendPropertyChanging();
					this._Cantidad = value;
					this.SendPropertyChanged("Cantidad");
					this.OnCantidadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Producto_DetallePedido", Storage="_Producto", ThisKey="ProductoId", OtherKey="Id", IsForeignKey=true)]
		public Producto Producto
		{
			get
			{
				return this._Producto.Entity;
			}
			set
			{
				Producto previousValue = this._Producto.Entity;
				if (((previousValue != value) 
							|| (this._Producto.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Producto.Entity = null;
						previousValue.DetallePedido.Remove(this);
					}
					this._Producto.Entity = value;
					if ((value != null))
					{
						value.DetallePedido.Add(this);
						this._ProductoId = value.Id;
					}
					else
					{
						this._ProductoId = default(int);
					}
					this.SendPropertyChanged("Producto");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pedido_DetallePedido", Storage="_Pedido", ThisKey="PedidoId", OtherKey="Id", IsForeignKey=true)]
		public Pedido Pedido
		{
			get
			{
				return this._Pedido.Entity;
			}
			set
			{
				Pedido previousValue = this._Pedido.Entity;
				if (((previousValue != value) 
							|| (this._Pedido.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pedido.Entity = null;
						previousValue.DetallePedido.Remove(this);
					}
					this._Pedido.Entity = value;
					if ((value != null))
					{
						value.DetallePedido.Add(this);
						this._PedidoId = value.Id;
					}
					else
					{
						this._PedidoId = default(int);
					}
					this.SendPropertyChanged("Pedido");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Estado")]
	public partial class Estado : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Nombre;
		
		private EntitySet<Pedido> _Pedido;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    #endregion
		
		public Estado()
		{
			this._Pedido = new EntitySet<Pedido>(new Action<Pedido>(this.attach_Pedido), new Action<Pedido>(this.detach_Pedido));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Estado_Pedido", Storage="_Pedido", ThisKey="Id", OtherKey="EstadoId")]
		public EntitySet<Pedido> Pedido
		{
			get
			{
				return this._Pedido;
			}
			set
			{
				this._Pedido.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Estado = this;
		}
		
		private void detach_Pedido(Pedido entity)
		{
			this.SendPropertyChanging();
			entity.Estado = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pedido")]
	public partial class Pedido : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ClienteId;
		
		private int _EstadoId;
		
		private EntitySet<DetallePedido> _DetallePedido;
		
		private EntityRef<Estado> _Estado;
		
		private EntityRef<Cliente> _Cliente;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnClienteIdChanging(int value);
    partial void OnClienteIdChanged();
    partial void OnEstadoIdChanging(int value);
    partial void OnEstadoIdChanged();
    #endregion
		
		public Pedido()
		{
			this._DetallePedido = new EntitySet<DetallePedido>(new Action<DetallePedido>(this.attach_DetallePedido), new Action<DetallePedido>(this.detach_DetallePedido));
			this._Estado = default(EntityRef<Estado>);
			this._Cliente = default(EntityRef<Cliente>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ClienteId", DbType="Int NOT NULL")]
		public int ClienteId
		{
			get
			{
				return this._ClienteId;
			}
			set
			{
				if ((this._ClienteId != value))
				{
					if (this._Cliente.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnClienteIdChanging(value);
					this.SendPropertyChanging();
					this._ClienteId = value;
					this.SendPropertyChanged("ClienteId");
					this.OnClienteIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EstadoId", DbType="Int NOT NULL")]
		public int EstadoId
		{
			get
			{
				return this._EstadoId;
			}
			set
			{
				if ((this._EstadoId != value))
				{
					if (this._Estado.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnEstadoIdChanging(value);
					this.SendPropertyChanging();
					this._EstadoId = value;
					this.SendPropertyChanged("EstadoId");
					this.OnEstadoIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pedido_DetallePedido", Storage="_DetallePedido", ThisKey="Id", OtherKey="PedidoId")]
		public EntitySet<DetallePedido> DetallePedido
		{
			get
			{
				return this._DetallePedido;
			}
			set
			{
				this._DetallePedido.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Estado_Pedido", Storage="_Estado", ThisKey="EstadoId", OtherKey="Id", IsForeignKey=true)]
		public Estado Estado
		{
			get
			{
				return this._Estado.Entity;
			}
			set
			{
				Estado previousValue = this._Estado.Entity;
				if (((previousValue != value) 
							|| (this._Estado.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Estado.Entity = null;
						previousValue.Pedido.Remove(this);
					}
					this._Estado.Entity = value;
					if ((value != null))
					{
						value.Pedido.Add(this);
						this._EstadoId = value.Id;
					}
					else
					{
						this._EstadoId = default(int);
					}
					this.SendPropertyChanged("Estado");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_Pedido", Storage="_Cliente", ThisKey="ClienteId", OtherKey="Id", IsForeignKey=true)]
		public Cliente Cliente
		{
			get
			{
				return this._Cliente.Entity;
			}
			set
			{
				Cliente previousValue = this._Cliente.Entity;
				if (((previousValue != value) 
							|| (this._Cliente.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Cliente.Entity = null;
						previousValue.Pedido.Remove(this);
					}
					this._Cliente.Entity = value;
					if ((value != null))
					{
						value.Pedido.Add(this);
						this._ClienteId = value.Id;
					}
					else
					{
						this._ClienteId = default(int);
					}
					this.SendPropertyChanged("Cliente");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DetallePedido(DetallePedido entity)
		{
			this.SendPropertyChanging();
			entity.Pedido = this;
		}
		
		private void detach_DetallePedido(DetallePedido entity)
		{
			this.SendPropertyChanging();
			entity.Pedido = null;
		}
	}
}
#pragma warning restore 1591