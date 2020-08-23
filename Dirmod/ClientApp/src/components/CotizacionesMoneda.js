import React, { Component } from 'react';
import CapitalizedText from './Utilidades/CapitalizedText'

export class CotizacionesMoneda extends Component {
    displayName = CotizacionesMoneda.name

    constructor(props) {
        super(props);
        this.state = { cotizaciones: [], loading: true };

    }

    componentWillMount() {
        fetch('cotizacion/getcotizaciones')
            .then(resp => {
                return resp.json()
            })
            .then(data => {
                this.setState({ cotizaciones: data, loading: false });
            })
            .catch(
                console.log()
            );
    }

    static renderCotizacionesTable(cotizaciones) {
        return (
            <table className='table'>
                <thead>
                    <tr>
                        <th>Moneda</th>
                        <th>Cotización</th>
                    </tr>
                </thead>
                <tbody>
                    {cotizaciones.map(moneda =>
                        <tr key={moneda.moneda}>
                            <td><CapitalizedText text = {moneda.moneda} /></td>
                            <td>$ {moneda.precio}</td>
                        </tr>

                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Cargando Cotizaciones...</em></p>
            : CotizacionesMoneda.renderCotizacionesTable(this.state.cotizaciones);

        return (
            <div>
                <h1>Cotizaciones</h1>
                {contents}
            </div>
        );
    }
}
