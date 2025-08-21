import { useEffect, useState } from 'react';
import ModelStructureApi from '../../../api/modelStructureApi';
import CurrencyApi from '../../../api/currencyApi';
import CurrencyFlag from 'react-currency-flags';

import './CurrencyTable.css'

const CurrencyTable = () => {
    const [hasColumns, setHasColumns] = useState(false)
    const [columns, setColumns] = useState([]);
    const [currencyList, setCurrencyList] = useState([]);
    const [currentCurrency, setCurrentCurrency] = useState();

    async function retrieveColumns() {
        if (hasColumns) {
            return;
        }

        var modelStructureExplorer = new ModelStructureApi();
        var columnData = null;
        await modelStructureExplorer.getCurrencyStructure()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    columnData = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });

        if (columnData){
            setColumns(columnData);
            setHasColumns(true);
        }
    }

    async function retrieveCurrencyList() {
        var currencyApi = new CurrencyApi();
        var data = null;
        await currencyApi.getCurrencyList()
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    data = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });
        
        var resultCodes = [];
        data.supportedCodes.map((priced, i) => {
            resultCodes[i] = [priced[0], priced[1], undefined]
        });
        // debugger
        setCurrencyList(resultCodes);
    }

    async function rateCurrency() {
        if (!currentCurrency) {
            return;
        }

        var currencyApi = new CurrencyApi();
        var currencyData = null;
        await currencyApi.getCurrencyRate(currentCurrency)
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    currencyData = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });

        var currencies = []
        var currencyRates = currencyData.conversionRates;
        currencyList.forEach((currency) => {
            var code = currency[0]; 
            currency[2] = currencyRates[code];
            currencies.push(currency);
        });

        setCurrencyList(currencies);
    }

    function displayColumns() {
        return (columns) ? (<tr>{columns.map((column) => {return <th key={column}>{column}</th>})}</tr>) : null
    }

    function displayRows() {
        return (currencyList) ? currencyList.map(key =>
        {
            var country = key[1];
            var price = key[2] ?? '--.--';
            return (<tr className="tableRow" key={key}>
                <td className="cell"><CurrencyFlag currency={key[0]} width={35} /></td>
                <td className="cell">{key[0]}</td>
                <td className="cell">{country}</td>
                <td className="cell">{price}</td>
            </tr>)
        }) : null
    }

    useEffect(() => {
        retrieveColumns();
        retrieveCurrencyList();
    }, [])

    return (<div className="baseContainer">
        <div className="baseSelectArea">
            <div className="baseTitle">
                <p>Rate currency : </p>
            </div>
            <div className="baseRange">
                <select value={currentCurrency ?? ''} onChange={(e) => setCurrentCurrency(e.target.value)}>
                    <option>Select currency.</option>
                    {currencyList.map(([code, title]) => { return <option key={code} value={code}>{code} {title}</option> } )}
                </select>
                <button className="convertButton" onClick={rateCurrency}>Rate</button>
            </div>
        </div>

        <div className="relateArea">
            <div className="relateTable">
                <table className="currencyTable">
                    <thead>
                        {displayColumns()}
                    </thead>
                    <tbody>
                        {displayRows()}
                    </tbody>
                </table>
            </div>
        </div>        
    </div>)
}

export default CurrencyTable;