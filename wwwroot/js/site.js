document.addEventListener("DOMContentLoaded", function () {
    const cargarProductosBtn = document.getElementById("cargarProductosBtn");
    if (cargarProductosBtn) {
        cargarProductosBtn.addEventListener("click", function () {
            fetch("/Productos/ObtenerProductos")
                .then(response => response.json())
                .then(data => {
                    if (data.length > 0) {
                        let productosHtml = "<ul>";
                        data.forEach(producto => {
                            productosHtml += `<li>${producto.tipoProducto || "Sin tipo"} - ${producto.marcaProducto || "Sin marca"} - $${producto.precioVenta?.toFixed(2) || "0.00"}</li>`;
                        });
                        productosHtml += "</ul>";
                        document.getElementById("productos-lista").innerHTML = productosHtml;

                        // Alerta de éxito
                        Swal.fire({
                            title: '¡Productos cargados!',
                            text: `Se han cargado ${data.length} productos.`,
                            icon: 'success',
                            confirmButtonText: 'Aceptar'
                        });
                    } else {
                        // Alerta de aviso
                        Swal.fire({
                            title: 'Sin productos',
                            text: 'No hay productos disponibles.',
                            icon: 'info',
                            confirmButtonText: 'Entendido'
                        });
                    }
                })
                .catch(error => {
                    console.error("Error al obtener los productos:", error);

                    // Alerta de error
                    Swal.fire({
                        title: 'Error',
                        text: 'Ocurrió un problema al cargar los productos.',
                        icon: 'error',
                        confirmButtonText: 'Intentar de nuevo'
                    });
                });
        });
    }
});

//document.addEventListener("click", function (event) {
//    if (event.target && event.target.id === "cargarProductosBtn") {
//        fetch("/Productos/ObtenerProductos")
//            .then(response => response.json())
//            .then(data => {
//                console.log("Datos recibidos:", data); // Revisa cómo llegan los datos
//                let productosHtml = "<ul>";
//                data.forEach(producto => {
//                    productosHtml += `<li>
//                                        ${producto.tipoProducto || "Sin tipo"} - 
//                                        ${producto.marcaProducto || "Sin marca"} - 
//                                        ${producto.modeloProducto || "Sin marca"} - 
//                                        ${producto.medidasProducto || "Sin marca"} - 
//                                        ${producto.colorProducto || "Sin marca"} - 
//                                        $${producto.precioCostoProducto || "Sin marca"} - 
//                                        $${producto.precioVenta || "0.00"}</li>`;
//                });
//                productosHtml += "</ul>";
//                document.getElementById("productos-lista").innerHTML = productosHtml;
//            })
//            .catch(error => {
//                console.error("Error al obtener los productos:", error);
//            });

//    }
//});

//Swal.fire({
//    title: '¡Éxito!',
//    text: 'Los productos se han cargado correctamente.',
//    icon: 'success',
//    confirmButtonText: 'Aceptar'
//});


//Swal.fire({
//    title: 'Error',
//    text: 'No se pudieron cargar los productos.',
//    icon: 'error',
//    confirmButtonText: 'Intentar de nuevo'
//});

//Swal.fire({
//    title: '¿Estás seguro?',
//    text: 'Esto eliminará el producto seleccionado.',
//    icon: 'warning',
//    showCancelButton: true,
//    confirmButtonText: 'Sí, eliminar',
//    cancelButtonText: 'Cancelar'
//}).then((result) => {
//    if (result.isConfirmed) {
//        // Aquí colocas la lógica para eliminar el producto
//        console.log('Producto eliminado');
//    }
//});
