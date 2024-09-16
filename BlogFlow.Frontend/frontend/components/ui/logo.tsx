import Link from 'next/link';
import { faHome } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';

export default function Logo() {
  return (
    <Link href="/" aria-label="Home" className="inline-flex items-center">
      <FontAwesomeIcon icon={faHome} className="text-gray-500 mr-2" />
    </Link>
  );
}
