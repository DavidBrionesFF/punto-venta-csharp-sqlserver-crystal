# Sistema de Punto de Venta en C# y SQL Server
En este sistema de punto de venta queremos que aprendas sobre como estructurar un proyecto en capas, utilizando el patron de diseño MVC.

Teniendo experiencia con el lenguaje de programacion Java, me hizo aprender a implementar patrones de diseño que se pueden implementar en este proyecto.

## ¿Que es MVC?

Mvc es un patron de diseño de software que nos permite estructurar nuestra aplicacion en capas, estas mismas interactuan entre si,
separando nuestro codigo y haciendolo mas legible. Su nombre viende  M - Modelo, V - Vista, C - Controlador.

Modelo: Es la capa encargada de manejar datos en nuestra aplicacion, transacciones en la base de datos, todo el mecanismo de trabajo de datos.

Vistas: Es la parte grafica de nuestra aplicacion que interactua con el cliente o usuario final, suelen llamarse interfaces graficas, en esta capa buscamos que el usuario haga sus peticiones.

Controlador: El controlador es el que maneja los eventos que se disparan cuando un usuario hace una accion en el sistema.

Servicio: Este es el encargado de manejar todos la logica de negocio, un ejemplo que vamos a hacer con la informacion que digito el usuario, como la pasaremos a modelo.

Repositorio: Esta capa es parte de nuestro modelo, ya que es aqui donde los datos se envian a la base de datos, ademas se encarga de que los datos de las tablas se conviertan a clases POJO.

![MVC](https://articulosvirtuales.com/uploads/images/photos/1/que_es_model_view_controller_mvc/Model-View-Controller%20(1).png)

Una vez entendiendo este patron, se que te salta la pregunta que ondas con el repositorio y el sevicio, de donde salen estos?, pues estos dos decidi agregarlos, porque las interfaces no son para manejar este codigo  ejemplo en una factura te traes un producto y lo validas si se encuentra, entonces piensa que pasa si en otro modulo necesitas dicha funcionalidad entonces necesitas llamar al modelo y validar, entonces aqui nace los componentes porque si hacer esa validacion requiere de muchos pasos pues puedes meterlo en una funcion y llamarla cuando se requiera.

¿Que es DAO?
Entonces dicho esto hay un patron de diseño llamado DAO, que viene de sus siglas Data Acces Object, el cual se encarga de separar el modelo en 3 partes fundamentales, los datos, el acceso a los datos y los objetos.

Para que entendamos mejor como estos funcionan pues si te fijas los datos de una base de datos por lo comun se pasa en un datareader o un dataset, pues estos datos asi no los comprende nuestra logica, porque hay nos encargamos de usar objetos, entonces necesitaremos una estructura mejor definida y asi manejar mejor el codigo.

Datos: La informacion que utiliza nuestra aplicacion, ya sea de una base de datos, de ficheros, etc...

Acceso: Aqui se define la logica de como accedemos a esa informacion, si es una base de datos nos conectamos, si es un fichero lo leemos etc...

Objetos: Esta es la parte que nos interesa en la aplicacion porque es lo que gestionaremos, luego se pasa a la capa de acceso y el se encarga de guardarlos.

![DAO](https://danielggarcia.files.wordpress.com/2009/05/dao.png)

Ahora si te fijas tenemos un software bien divido por partes, pero falta algo. Siempre que estuve en el bachillerato recuerdo mis compañeros que siempre que hacian una transaccion pues se tenia que abrir una conexion a una base de datos y pues eso hace que las transacciones sean muy lentas, no abria una forma de que en todo el software siempre esta abierta la conexion, pues si cargandolo en una variable estatica y listo.

¿Que es Singleton?

Es un patron de diseño que nos permite que solo se encuentre una sola instancia de una clase en concreto, un ejemplo te creas la clase carro pues este patron hace que no puedas crear mas de un solo carro, pues lo vez en nuestra base de datos viene como anillo al dedo.

![Singleton](https://lh5.googleusercontent.com/proxy/uzkd3co014mEUYYKZuzF7AGWDLJP2SgnTMFsjJgHf46RE2Rw2FLVFEUYvH1cPnu-CPUQAL0EEi9r9UolXdB0YvxNaVmfgsgPteMyCVYimLhFb5Z5ieH46wI)

Una vez dicho esto puedes empezar a desarrollar el sistema el cual te dejare la explicacion en el siguiente video, suscribete para mas videos!!

Video de Documentacion y Explicacion Aqui: https://www.youtube.com/watch?v=tM-7GbLMqZs

![Sistema](https://github.com/DavidBrionesFF/punto-venta-csharp-sqlserver-jasperreport/blob/master/db.jpg?raw=true)
