import "./popup.css"

const Popup = (inputObj, onClose, action) => {
    const setButton = (btnObject) => {
        return <button className="popupButton" onClick={btnObject.onTrigger}>{btnObject.header}</button>
    }

    return <div className="popupBackground"> 
        <div className="popup">
            <div className="contentBanner">
                <h1 className="title">{inputObj.title}</h1>
                <a>Do you want to delete {inputObj.object} user?</a>
            </div>
            <div className="buttonsArea">
                <div className="popupButtons">
                    {setButton(onClose)}
                    {setButton(action)}
                </div>
            </div>
        </div>
    </div>;
}

export default Popup;