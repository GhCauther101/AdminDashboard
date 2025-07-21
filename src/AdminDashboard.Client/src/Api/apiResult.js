class ApiResult {
    _isSuccess = false;
    _status = null;
    _data = null;

    define = (isSuccess, status, data) => {
        this._isSuccess = isSuccess;
        this._status = status;
        this._data = data;
    }

    get = () => {
        return {
            isSuccess: this._isSuccess,
            status: this._status,
            data: this._data
        };
    }
}

export default ApiResult;