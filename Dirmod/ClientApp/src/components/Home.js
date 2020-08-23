import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
    return (
      <div>
        <h1>Bienvenidos!</h1>
            <p>Esta p&aacute;gina es de prueba, la misma se utiliza para mostrar los datos de un cotizador en l&iacute;nea consultado por medio de una WebAPI.</p>
      </div>
    );
  }
}
