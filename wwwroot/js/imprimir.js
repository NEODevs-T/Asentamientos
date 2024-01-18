function imprimirElemento(uri){
    setTimeout(function(){
        window.print()
        window.location.replace(uri + "Impresion") 
    }, 600);
}
