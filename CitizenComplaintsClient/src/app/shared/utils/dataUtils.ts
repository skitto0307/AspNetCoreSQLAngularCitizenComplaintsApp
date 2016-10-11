
export function NewGuid() :string{
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c)=> {
            let _random = Math.random() * 16 | 0, _v = c == 'x' ? _random : (_random & 0x3 | 0x8);
            return _v.toString(16);
        });
}