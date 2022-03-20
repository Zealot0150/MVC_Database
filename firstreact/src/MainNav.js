import { Link } from 'react-router-dom';

function MainNav() {
    return (
        <header>
            <div>Zealot 0150</div>
            <nav>
                <ul>
                    <li>
                        <Link to='/addPerson'>Lägg till Person</Link>
                    </li>
                    <li>
                        <Link to='/peoplelist'>Lista Personer</Link>
                    </li>
                </ul>
            </nav>
        </header>
    );
}

export default MainNav;