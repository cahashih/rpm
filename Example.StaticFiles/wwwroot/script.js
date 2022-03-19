const getFormJSON = (form) => {
    const data = new FormData(form);
    return Array.from(data.keys()).reduce((result, key) => {
        result[key] = data.get(key);
        return result;
    }, {});
};

const GetData = async (uri) => {
    let result = await fetch(uri);
    return await result.json();
}

const PostData = async (uri, body) => {
    await fetch(uri, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(body)
    });
}