import { useEffect, useState } from "react";
import CurrencyApi from "../../../api/currencyApi";
import { IoIosArrowBack } from "react-icons/io";

import "./PairCurrencyDisplay.css"
import { useNavigate } from "react-router-dom";

const PairCurrencyDisplay = () => {
    const navigate = useNavigate();
    const [amount, setAmount] = useState(1);
    const [baseCurrency, setBaseCurrency] = useState();
    const [targetCurrency, setTargetCurrency] = useState();
    const [rate, setRate] = useState();
    const [result, setResult] = useState();
    const [currencyList, setCurrencyList] = useState([]);

    async function getCurrencyCodes() {
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
            resultCodes[i] = [priced[0], priced[1]]
        });

        setCurrencyList(resultCodes);
    }

    const convertCurrency = async (e) => {
        e.preventDefault();

        if (!baseCurrency || !targetCurrency) {
            return;
        }

        var currencyApi = new CurrencyApi();
        var data = null;
        await currencyApi.getPairRate(baseCurrency, targetCurrency)
            .then(resp => 
            {
                var result = resp.parse();
                if (result.isSuccess && result.status === 200) {
                    data = result.data;
                } else if (!result.isSuccess) {
                    setErrors(result.data);
                }
            });

        var rate = data.conversionRate.toFixed(2);
        var result = (amount * rate).toFixed(2);
        
        setRate(rate);
        setResult(result);
    }

    const moveBack = () => {
        navigate(-1);
    }

    useEffect(() => {
        getCurrencyCodes();
    }, []);

    return (
        <div className="wrapper">
            <div className="titleArea">
                <div className="icon" onClick={moveBack}>
                    <IoIosArrowBack />
                </div>
                <div className="title">
                    <p>Currency convert</p>
                </div>
            </div>
            <div className="formArea">
                <form>
                    <div className="currencyAmount">
                        <input type="text" placeholder="amount" required value={amount} onChange={(e) => setAmount(e.target.value)} />
                    </div>
                    <div className="dropdownArea">
                        <select value={baseCurrency ?? ''} onChange={(e) => setBaseCurrency(e.target.value)}>
                            <option>Select source currency.</option>
                            {currencyList.map(([code, title]) => { return <option key={code} value={code}>{code} {title}</option> } )}
                        </select>

                        <select value={targetCurrency ?? ''} onChange={(e) => setTargetCurrency(e.target.value)}>
                            <option>Select destination currency.</option>
                            {currencyList.map(([code, title]) => { return <option key={code} value={code}>{code} {title}</option> } )}
                        </select>
                    </div>
                    <div className="resultDisplay">
                        <button onClick={convertCurrency}>Convert</button>
                        <div className="convertResult">
                            <div className="rateSection">
                                <p>Rate : </p>
                                {rate ?? '--.--'}
                            </div>
                            <div className="resultSection">
                                <p>Total result : </p>
                                {result ?? '--.--'}
                            </div>                            
                        </div>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default PairCurrencyDisplay;