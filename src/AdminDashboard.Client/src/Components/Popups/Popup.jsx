const Popup = (isShowPopup, onClose, content, action) => {
    if (!isShowPopup) return null;

    const setButton = (btnObject) => {
        return <button className="popupButton" onClick={btnObject.onTrigger}>{btnObject.header}</button>
    }

    return (
        <div className="popup">
            {content}

            <div className="popupButtons">
                {setButton(onClose)}
                {setButton(action)}
            </div>
        </div>
    )
}

const displayDeletePopup = (isShowPopup, onClose, object, action) => {
    const deletePopupContent = () => {
        return (
        <div className="contentBanner">
            <a>Do you want to delete {object.username} user?</a>
        </div>)
    }

    return Popup(isShowPopup, onClose, deletePopupContent, action);
}

export default displayDeletePopup;