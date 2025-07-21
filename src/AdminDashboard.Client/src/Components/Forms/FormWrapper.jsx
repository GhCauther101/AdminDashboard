const plateError = (field) => {
    return <div style={{ color: '#f54242', borderRadius: '5px', background: '#cbcbcb', textAlign: 'center'}}><span>{field.join(', ')}</span></div>;
}

export default plateError;